using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTab : MonoBehaviour
{
    public List<GameObject> list = new List<GameObject>();
    public GameObject showMe;

    public void onClickShowMe()
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].SetActive(false);
        }
        showMe.SetActive(true);


    }

}
