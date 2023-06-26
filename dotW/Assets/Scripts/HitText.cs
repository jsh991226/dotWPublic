using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;


public class HitText : MonoBehaviour
{
    public List<Texture> hitImage = new List<Texture>();

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeImage(int hitLv)
    {
        gameObject.GetComponent<RawImage>().enabled = true;
        gameObject.GetComponent<RawImage>().texture = hitImage[hitLv];
        
        StartCoroutine(changeWait());

    }
    IEnumerator changeWait()
    {
        Color color = gameObject.GetComponent<RawImage>().color; ;
        while (gameObject.GetComponent<RawImage>().color.a > 0)
        {
            color.a -= 0.2f;
            gameObject.GetComponent<RawImage>().color = color;
            yield return new WaitForSeconds(0.08f);
        }
        color.a = 1.0f;
        gameObject.GetComponent<RawImage>().color = color;
        gameObject.GetComponent<RawImage>().enabled = false;
    }

}
