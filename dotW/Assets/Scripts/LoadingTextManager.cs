using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingTextManager : MonoBehaviour
{
    public string[] TmiTextArray;

    public Text tmiText;
    void Start()
    {
        tmiText.text = TmiTextArray[Random.Range(0, TmiTextArray.Length)];
    }
    int count = 0;
    void Update()
    {
        if (count <= 300) { count++; }
        else
        {
            count = 0;
            tmiText.text = TmiTextArray[Random.Range(0, TmiTextArray.Length)];
        }

    }
}
