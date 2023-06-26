using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescManager : MonoBehaviour
{
    public GameObject itemDescBox;
    public Text itemDescText;
    public Text itemNameText;
    public string itemNameString;
    public string itemDescString;

    public void OnHoverIn()
    {
        if (itemNameString.Length > 0)
        {
            itemDescBox.SetActive(true);
            itemDescText.text = itemDescString;
            itemNameText.text = itemNameString;
        }
    }

    public void OnHoverOut()
    {
        itemDescBox.SetActive(false);
    }
}
