using System;
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CUIColorPicker : MonoBehaviour
{
    


    public Color Color { get { return _color; } set { Setup( value ); } }
    public void SetOnValueChangeCallback( Action<Color> onValueChange )
    {
        _onValueChange = onValueChange;
    }
    private Color _color = Color.red;
    private Action<Color> _onValueChange;
    private Action _update;
    public Camera uiCamera;
    public GameObject CheckBoxList;
    public int nowSel;
    public GameObject frogModel;
    public GameObject playerPhotonModel;
    public GameObject applyMsgObj;
    private IEnumerator applyMsgCor;
    private Image applyMsgCompo;


    private void RGBToHSV( Color color, out float h, out float s, out float v )
    {
        var cmin = Mathf.Min( color.r, color.g, color.b );
        var cmax = Mathf.Max( color.r, color.g, color.b );
        var d = cmax - cmin;
        if ( d == 0 ) {
            h = 0;
        } else if ( cmax == color.r ) {
            h = Mathf.Repeat( ( color.g - color.b ) / d, 6 );
        } else if ( cmax == color.g ) {
            h = ( color.b - color.r ) / d + 2;
        } else {
            h = ( color.r - color.g ) / d + 4;
        }
        s = cmax == 0 ? 0 : d / cmax;
        v = cmax;
    }

    private bool GetLocalMouse( GameObject go, out Vector2 result ) 
    {
        var rt = ( RectTransform )go.transform;
        Vector2 mp;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, Input.mousePosition, uiCamera, out mp);
        result.x = Mathf.Clamp( mp.x, rt.rect.min.x, rt.rect.max.x );
        result.y = Mathf.Clamp( mp.y, rt.rect.min.y, rt.rect.max.y );
        return rt.rect.Contains( mp );
    }

    private Vector2 GetWidgetSize( GameObject go ) 
    {
        var rt = ( RectTransform )go.transform;
        return rt.rect.size;
    }

    private GameObject GO( string name )
    {
        return transform.Find(name).gameObject;
    }

    private void Setup( Color inputColor )
    {
        var satvalGO = GO( "SaturationValue" );
        var satvalKnob = GO( "SaturationValue/Knob" );
        var hueGO = GO( "Hue" );
        var hueKnob = GO( "Hue/Knob" );
        var result = GO( "Result" );
        var hueColors = new Color [] {
            Color.red,
            Color.yellow,
            Color.green,
            Color.cyan,
            Color.blue,
            Color.magenta,
        };
        var satvalColors = new Color [] {
            new Color( 0, 0, 0 ),
            new Color( 0, 0, 0 ),
            new Color( 1, 1, 1 ),
            hueColors[0],
        };
        var hueTex = new Texture2D( 1, 7 );
        for ( int i = 0; i < 7; i++ ) {
            hueTex.SetPixel( 0, i, hueColors[i % 6] );
        }
        hueTex.Apply();
        hueGO.GetComponent<Image>().sprite = Sprite.Create( hueTex, new Rect( 0, 0.5f, 1, 6 ), new Vector2( 0.5f, 0.5f ) );
        var hueSz = GetWidgetSize( hueGO );
        var satvalTex = new Texture2D(2,2);
        satvalGO.GetComponent<Image>().sprite = Sprite.Create( satvalTex, new Rect( 0.5f, 0.5f, 1, 1 ), new Vector2( 0.5f, 0.5f ) );
        Action resetSatValTexture = () => {
            for ( int j = 0; j < 2; j++ ) {
                for ( int i = 0; i < 2; i++ ) {
                    satvalTex.SetPixel( i, j, satvalColors[i + j * 2] );
                }
            }
            satvalTex.Apply();
        };
        var satvalSz = GetWidgetSize( satvalGO );
        float Hue, Saturation, Value;
        RGBToHSV( inputColor, out Hue, out Saturation, out Value );
        Action applyHue = () => {
            var i0 = Mathf.Clamp( ( int )Hue, 0, 5 );
            var i1 = ( i0 + 1 ) % 6;
            var resultColor = Color.Lerp( hueColors[i0], hueColors[i1], Hue - i0 );
            satvalColors[3] = resultColor;
            resetSatValTexture();
        };
        Action applySaturationValue = () => {
            var sv = new Vector2( Saturation, Value );
            var isv = new Vector2( 1 - sv.x, 1 - sv.y );
            var c0 = isv.x * isv.y * satvalColors[0];
            var c1 = sv.x * isv.y * satvalColors[1];
            var c2 = isv.x * sv.y * satvalColors[2];
            var c3 = sv.x * sv.y * satvalColors[3];
            var resultColor = c0 + c1 + c2 + c3;
            var resImg = result.GetComponent<Image>();
            resImg.color = resultColor;
            if ( _color != resultColor ) {
                if ( _onValueChange != null ) {
                    _onValueChange( resultColor );
                }
                _color = resultColor;
            }
        };
        applyHue();
        applySaturationValue();
        satvalKnob.transform.localPosition = new Vector2( Saturation * satvalSz.x, Value * satvalSz.y );
        hueKnob.transform.localPosition = new Vector2( hueKnob.transform.localPosition.x, Hue / 6 * satvalSz.y );
        Action dragH = null;
        Action dragSV = null;
        Action idle = () => {
            if ( Input.GetMouseButtonDown( 0 ) ) {
                Vector2 mp;
                if ( GetLocalMouse( hueGO, out mp ) ) {
                    _update = dragH;
                } else if ( GetLocalMouse( satvalGO, out mp ) ) {
                    _update = dragSV;
                }
            }
        };
        dragH = () => {
            Vector2 mp;
            GetLocalMouse( hueGO, out mp );
            Hue = mp.y / hueSz.y * 6;
            applyHue();
            applySaturationValue();
            hueKnob.transform.localPosition = new Vector2( hueKnob.transform.localPosition.x, mp.y );
            if ( Input.GetMouseButtonUp( 0 ) ) {
                _update = idle;
            }
        };
        dragSV = () => {
            Vector2 mp;
            GetLocalMouse( satvalGO, out mp );
            Saturation = mp.x / satvalSz.x;
            Value = mp.y / satvalSz.y;
            applySaturationValue();
            satvalKnob.transform.localPosition = mp;
            if ( Input.GetMouseButtonUp( 0 ) ) {
                _update = idle;
            }
        };
        _update = idle;
    }

    public void SetRandomColor()
    {
        var rng = new System.Random();
        var rdr = ( rng.Next() % 1000 ) / 1000.0f;
        var rdg = ( rng.Next() % 1000 ) / 1000.0f;
        var rdb = ( rng.Next() % 1000 ) / 1000.0f;
        Color = new Color( rdr, rdg, rdb );
    }

    public void onSelect()
    {
        //GameObject.Find("GameManager").GetComponent<GameManager>().playerColorchange(frogModel.GetComponent<CustomModelManager>().modelStomach.GetComponent<Renderer>().material.color, frogModel.GetComponent<CustomModelManager>().modelCheek.GetComponent<Renderer>().material.color, frogModel.GetComponent<CustomModelManager>().modelBody.GetComponent<Renderer>().material.color);
        //playerPhotonModel.GetComponent<playerManager>().playerColorchange(frogModel.GetComponent<CustomModelManager>().modelStomach.GetComponent<Renderer>().material.color, frogModel.GetComponent<CustomModelManager>().modelCheek.GetComponent<Renderer>().material.color, frogModel.GetComponent<CustomModelManager>().modelBody.GetComponent<Renderer>().material.color);
        Color stomach = frogModel.GetComponent<CustomModelManager>().modelStomach.GetComponent<Renderer>().material.color;
        Color body = frogModel.GetComponent<CustomModelManager>().modelBody.GetComponent<Renderer>().material.color;
        Color cheek = frogModel.GetComponent<CustomModelManager>().modelCheek.GetComponent<Renderer>().material.color;
        GameObject.Find("Player(Clone)").GetComponent<playerManager>().playerColorchange(stomach, cheek, body);
        applyMsgObj.SetActive(true);
        if (applyMsgCor != null)
        {
            StopCoroutine(applyMsgCor);
            Color tempColor = applyMsgCompo.color;
            tempColor.a = 1;
            applyMsgCompo.color = tempColor;

        }
        applyMsgCor = closeMsg();
        StartCoroutine(applyMsgCor);


    }
    IEnumerator closeMsg()
    {
        yield return new WaitForSeconds(0.5f);
        Color changeColor = applyMsgCompo.color;
        while (applyMsgCompo.color.a > 0)
        {
            changeColor.a -= 0.1f;
            applyMsgCompo.color = changeColor;
            yield return new WaitForSeconds(0.09f);
        }
        applyMsgObj.SetActive(false);

    }



    void Awake()
    {
        applyMsgCompo = applyMsgObj.GetComponent<Image>();

    }
    private void Start()
    {
        float bR, bG, bB;
        float sR, sG, sB;
        float cR, cG, cB;
        string[] colorSplit = GameObject.Find("GameManager").GetComponent<GameManager>().userColorCode.Split(':', '-');
        bR = (float.Parse(colorSplit[0]));
        bG = (float.Parse(colorSplit[1]));
        bB = (float.Parse(colorSplit[2]));
        sR = (float.Parse(colorSplit[3]));
        sG = (float.Parse(colorSplit[4]));
        sB = (float.Parse(colorSplit[5]));
        cR = (float.Parse(colorSplit[6]));
        cG = (float.Parse(colorSplit[7]));
        cB = (float.Parse(colorSplit[8]));
        frogModel.GetComponent<CustomModelManager>().modelBody.GetComponent<Renderer>().material.color = new Color(bR, bG, bB);
        frogModel.GetComponent<CustomModelManager>().modelCheek.GetComponent<Renderer>().material.color = new Color(cR, cG, cB);
        frogModel.GetComponent<CustomModelManager>().modelStomach.GetComponent<Renderer>().material.color = new Color(sR, sG, sB);
        nowSel = 3;
        Color = frogModel.GetComponent<CustomModelManager>().modelBody.GetComponent<Renderer>().material.color;
    }


    void Update()
    {
        _update();
        frogModel.GetComponent<CustomModelManager>().changeColor(nowSel, Color);
    }
    private void selChange(int selnum)
    {
        nowSel = selnum;
        
    }
    


    public void onSelect_1() { selChange(1); Color = frogModel.GetComponent<CustomModelManager>().modelStomach.GetComponent<Renderer>().material.color;}
    public void onSelect_2() { selChange(2); Color = frogModel.GetComponent<CustomModelManager>().modelCheek.GetComponent<Renderer>().material.color; }
    public void onSelect_3() { selChange(3); Color = frogModel.GetComponent<CustomModelManager>().modelBody.GetComponent<Renderer>().material.color; }

}
