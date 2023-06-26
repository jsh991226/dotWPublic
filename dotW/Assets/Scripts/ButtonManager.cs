using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    public Button pb;
    public RawImage tex;
    public Texture defaultTex;
    public Texture newTex;
    public void OnPointerEnter(PointerEventData eventData)
    {
        tex.texture = newTex;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tex.texture = defaultTex;
    }
}