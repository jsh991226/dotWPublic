using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MsgBox : MonoBehaviour
{
    public GameObject boxImg;
    public GameObject text;
    public Sprite redImg;
    public Sprite greenImg;
    private Image boxImgCompo;
    private Text textCompo;
    private int showFrame = 10;
    private Color boxColor;
    private float maxOpacity = 0.65f;
    private Color textColor;
    IEnumerator showIng;
    private void Awake()
    {
        boxImgCompo = boxImg.GetComponent<Image>();
        textCompo = text.GetComponent<Text>();
        boxColor = boxImgCompo.color;
        textColor = textCompo.color;
    }
    public void clickStop()
    {
        StopCoroutine(showIng);
        hideMsg();
    }
    public void changeColor(bool isError)
    {
        if (isError) boxImgCompo.sprite = redImg;
        else boxImgCompo.sprite = greenImg;
    }
    public void hideMsg()
    {
        boxImg.SetActive(false);
        text.SetActive(false);
    }
    public void viewMsg(string msg, float time, bool isError)
    {
        changeColor(isError);
        text.GetComponent<Text>().text = msg;
        showIng = showTimer(time);
        StartCoroutine(showIng);

    }
    public void viewMsg(string msg, float time)
    {
        changeColor(false);
        text.GetComponent<Text>().text = msg;
        showIng = showTimer(time);
        StartCoroutine(showIng);
    }

    IEnumerator showTimer(float time)
    {
        boxColor.a = 0;
        boxImgCompo.color = boxColor;
        textColor.a = 0;
        textCompo.color = textColor;
        boxImg.SetActive(true);
        text.SetActive(true);
        int i = 0;
        float pmFrame = 1f * maxOpacity / showFrame;
        while (i< showFrame)
        {
            textColor.a += pmFrame;
            boxColor.a += pmFrame;
            boxImgCompo.color = boxColor;
            textCompo.color = textColor;
            i++;
            yield return new WaitForSeconds(time/5/showFrame);
        }
        yield return new WaitForSeconds(time / 5 *3);
        while (i > 0)
        {
            textColor.a -= pmFrame;
            boxColor.a -= pmFrame;
            boxImgCompo.color = boxColor;
            textCompo.color = textColor;
            i--;
            yield return new WaitForSeconds(time / 5 / showFrame);
        }
        hideMsg();
    }


}
