using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class soundProgress : MonoBehaviour, IDragHandler
{
    public Camera uiCamera;
    public GameObject backBar;
    public GameObject inIcon;
    public GameObject inBar;
    RectTransform inBarRt;
    float defaultHeight;
    public GameObject soundIcon;
    public Texture soundDefaultTex;
    public Texture soundMuteTex;

    void Start()
    {
        var iconRt = (RectTransform)inIcon.transform;

        inBarRt = (RectTransform)inBar.transform;
        defaultHeight = inBarRt.rect.height;


    }
    public void OnDrag(PointerEventData eventData)
    {
        moveIcon();
    }

    private void moveIcon()
    {
        var rt = (RectTransform)backBar.transform;
        var iconRt = (RectTransform)inIcon.transform;
        Vector2 mp;
        Vector2 result;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, Input.mousePosition, uiCamera, out mp);
        float temp = rt.rect.max.y;
        mp.y += temp;
        result.x = Mathf.Clamp(mp.x, rt.rect.min.x, rt.rect.max.x); //(iconRt.rect.max.y / 2)
        result.y = Mathf.Clamp(mp.y, (rt.rect.min.y + temp + (iconRt.rect.max.y)), (rt.rect.max.y + temp -0));
        if ((mp.x >= rt.rect.min.x && mp.x <= rt.rect.max.x) && (mp.y >= rt.rect.min.y+temp && mp.y <= rt.rect.max.y+temp))
        {
            inIcon.transform.localPosition = new Vector2(inIcon.transform.localPosition.x, result.y+ iconRt.rect.max.y/2);
            inBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, inIcon.transform.localPosition.y- (iconRt.rect.max.y / 2));
            if ((defaultHeight / 10) > (inIcon.transform.localPosition.y - (iconRt.rect.max.y / 2)))
            {
                soundIcon.GetComponent<RawImage>().texture = soundMuteTex;
                Camera.main.GetComponent<AudioSource>().mute = true;
            }
            else if (Camera.main.GetComponent<AudioSource>().mute == true)
            {
                soundIcon.GetComponent<RawImage>().texture = soundDefaultTex;
                Camera.main.GetComponent<AudioSource>().mute = false;
            } else
            {
                Camera.main.GetComponent<AudioSource>().volume = inIcon.transform.localPosition.y / defaultHeight;
            }
        }
    }

    public void onMuteToggle()
    {
        if (Camera.main.GetComponent<AudioSource>().mute == true)
        {
            Camera.main.GetComponent<AudioSource>().mute = false;
            soundIcon.GetComponent<RawImage>().texture = soundDefaultTex;

        } else
        {
            Camera.main.GetComponent<AudioSource>().mute = true;
            soundIcon.GetComponent<RawImage>().texture = soundMuteTex;
            var rt = (RectTransform)backBar.transform;
            var iconRt = (RectTransform)inIcon.transform;
            float temp = rt.rect.min.y + rt.rect.max.y + (iconRt.rect.max.y);
            inIcon.transform.localPosition = new Vector2(inIcon.transform.localPosition.x, temp);
            inBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, inIcon.transform.localPosition.y - (iconRt.rect.max.y / 2));



        }

    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            moveIcon();
        }

    }
}
