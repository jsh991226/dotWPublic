using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notes : MonoBehaviour
{
    // Start is called before the first frame update
    public int nowImgNum = 0;
    public List<Texture> noteShowImg = new List<Texture>();
    public List<Texture> noteGrowUpImg = new List<Texture>();
    public List<Texture> noteBreakImg = new List<Texture>();
    public int upCnt = 0;
    public int growUpCnt = 0;
    public bool imGrown = false;

    IEnumerator growUpCor;

    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (noteShowImg.Count > nowImgNum)
        {
            upCnt++;
            if (upCnt > 3)
            {
                gameObject.GetComponent<RawImage>().texture = noteShowImg[nowImgNum];
                nowImgNum++;
                upCnt = 0;
            }
        }
    }






    public void destroyMe()
    {
        StartCoroutine(noteBreak());
    }
    public void noteHitAni(int jumplvint)
    {
        StartCoroutine(noteBreakAni(jumplvint));
    }
    public void growUp()
    {
        imGrown = true;
        growUpCor = noteSizeChange();
        StartCoroutine(growUpCor);
    }




    IEnumerator noteBreak()
    {
        Color color = gameObject.GetComponent<RawImage>().color;
        while (gameObject.GetComponent<RawImage>().color.a > 0.0f)
        {
            color.a -= 0.1f;
            gameObject.GetComponent<RawImage>().color = color;
            yield return new WaitForSeconds(0.008f);
        }
        Destroy(gameObject);
    }

    IEnumerator noteBreakAni(int jumplvint)
    {
        StopCoroutine(growUpCor);
        int noteBreakCount = (7 * (jumplvint - 1));
        while (7 * jumplvint > noteBreakCount)
        {
            gameObject.GetComponent<RawImage>().texture = noteBreakImg[noteBreakCount];
            noteBreakCount++;
            yield return new WaitForSeconds(0.008f);
        }
        Destroy(gameObject);
    }

    IEnumerator noteSizeChange()
    {
        int noteGrowUpCount = 0;
        while (noteGrowUpImg.Count > noteGrowUpCount)
        {
            growUpCnt++;
            if (growUpCnt > 2)
            {
                gameObject.GetComponent<RawImage>().texture = noteGrowUpImg[noteGrowUpCount];
                noteGrowUpCount++;
                growUpCnt = 0;
            }
            yield return new WaitForSeconds(0.008f);
        }
    }



}
