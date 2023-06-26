using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CheckBtnManager : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    public RawImage tex;
    public Texture defaultTex;
    public Texture newTex;
    public List<GameObject> checkList = new List<GameObject>();
    public bool isClick;
    public bool isHover;
    private void Start()
    {
        if (isClick == true) tex.texture = newTex;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isHover == true ) tex.texture = newTex;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isClick != true && isHover == true) tex.texture = defaultTex;
    }
    public void onClick()
    {
        
        for (int i = 0; i < checkList.Count; i++)
        {
            checkList[i].GetComponent<RawImage>().texture = checkList[i].GetComponent<CheckBtnManager>().defaultTex;
            checkList[i].GetComponent<CheckBtnManager>().isClick = false;
        }
        isClick = true;
        gameObject.GetComponent<RawImage>().texture = newTex;

    }

}