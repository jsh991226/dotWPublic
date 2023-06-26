using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RowInst : MonoBehaviour
{
    public TextMeshProUGUI text = null;
    public int level;
    public string titleText;
    public Image starImg;
    public Image stampImg;
    public int index;
    private void Awake()
    {
        if (!(level > 0)) level = 1;
    }


    public void UpdateContent(string titleText)
    {
        text.text = titleText;
    }


}
