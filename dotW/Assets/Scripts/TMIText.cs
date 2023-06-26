using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TMIText : MonoBehaviour
{
    public string[] TmiTextArray =
        {
        "Hello ㅋㅋㄹㅃㅃ",
        "Help Me!!! ㅋㅋ",
        "쪼끔만 기다리셈 ㅋㅋ"
        };
    public Text tmiText;
    void Start()
    {
        tmiText.text = TmiTextArray[Random.Range(0, TmiTextArray.Length)];
    }
    int count = 0;
    void Update()
    {
        if (count <= 500) { count++; }
        else
        {
            count = 0;
            tmiText.text = TmiTextArray[Random.Range(0, TmiTextArray.Length)];
        }

    }
}
