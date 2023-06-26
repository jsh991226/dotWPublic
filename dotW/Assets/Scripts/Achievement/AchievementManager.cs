using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{

    public List<GameObject> rowList = new List<GameObject>();
    public List<Sprite> starImg = new List<Sprite>();
    [SerializeField]
    private Text nowPageText;
    [SerializeField]
    private Text maxPageText;

    public List<AchievementItemManager> achiList = new List<AchievementItemManager>();
    private int nowPage = 1;
    private int maxPage;
    private int rowsCount = 8;

    private void Awake()
    {
        achiList.Add(new AchiItem_1());
        achiList.Add(new AchiItem_2());
        achiList.Add(new AchiItem_3());
        achiList.Add(new AchiItem_4());
        achiList.Add(new AchiItem_5());
        achiList.Add(new AchiItem_6());
        achiList.Add(new AchiItem_7());
        achiList.Add(new AchiItem_8());
        achiList.Add(new AchiItem_9());
        achiList.Add(new AchiItem_10());
        achiList.Add(new AchiItem_11());
        achiList.Add(new AchiItem_12());
        achiList.Add(new AchiItem_13());
        achiList.Add(new AchiItem_14());
        achiList.Add(new AchiItem_15());
        achiList.Add(new AchiItem_16());
        achiList.Add(new AchiItem_17());
        achiList.Add(new AchiItem_18());
        achiList.Add(new AchiItem_19());
        achiList.Add(new AchiItem_20());
        achiList.Add(new AchiItem_21());
        achiList.Add(new AchiItem_22());
        achiList.Add(new AchiItem_23());
        achiList.Add(new AchiItem_24());
        achiList.Add(new AchiItem_25());
        achiList.Add(new AchiItem_26());
        achiList.Add(new AchiItem_27());
        achiList.Add(new AchiItem_28());
        achiList.Add(new AchiItem_29());
        achiList.Add(new AchiItem_30());
        achiList.Add(new AchiItem_31());
        achiList.Add(new AchiItem_32());
        achiList.Add(new AchiItem_33());
        achiList.Add(new AchiItem_34());
        achiList.Add(new AchiItem_35());
        achiList.Add(new AchiItem_36());
        achiList.Add(new AchiItem_37());
        achiList.Add(new AchiItem_38());
        achiList.Add(new AchiItem_39());
        achiList.Add(new AchiItem_40());
        achiList.Add(new AchiItem_41());
        achiList.Add(new AchiItem_42());
        achiList.Add(new AchiItem_43());
        achiList.Add(new AchiItem_44());
        achiList.Add(new AchiItem_45());
        achiList.Add(new AchiItem_46());
        achiList.Add(new AchiItem_47());
        achiList.Add(new AchiItem_48());
        achiList.Add(new AchiItem_49());
        achiList.Add(new AchiItem_50());
        achiList.Add(new AchiItem_51());
        achiList.Add(new AchiItem_52());
        achiList.Add(new AchiItem_53());
        achiList.Add(new AchiItem_54());
        achiList.Add(new AchiItem_55());
        achiList.Add(new AchiItem_56());
        achiList.Add(new AchiItem_57());
        achiList.Add(new AchiItem_58());
        achiList.Add(new AchiItem_59());
        achiList.Add(new AchiItem_60());
        achiList.Add(new AchiItem_61());
        achiList.Add(new AchiItem_62());


    }

    private void Start()
    {
        maxPage = (achiList.Count / rowsCount);
        if (achiList.Count % rowsCount > 0) maxPage++;
        maxPageText.text = maxPage.ToString();
        ViewPage();
    }
    public void PlayerJoinCheck()
    {
        List<string> columns = new List<string>();
        for ( int i = 0; i < achiList.Count; i++)
        {
            columns.Add(achiList[i].columnName);
        }
        List<string> resultString = new List<string>();
        var thread2 = new Thread(
        () =>
        {
            try
            {
                resultString = BackEndGameInfo.GetData("UserData", columns);
            }
            finally
            {
                for (int i = 0; i < achiList.Count; i++)
                {
                    achiList[i].CheckCount(int.Parse(resultString[i]));
                }

            }
        });
        thread2.Start();
    }



    public void ViewPage()
    {
        nowPageText.text = nowPage.ToString();
        int loopCount = rowsCount * (nowPage - 1);
        for (int i = loopCount; i < loopCount+rowsCount; i++)
        {
            if (i > achiList.Count-1) rowList[i - loopCount].SetActive(false);
            else
            {
                rowList[i - loopCount].SetActive(true);
                rowList[i - loopCount].GetComponent<RowInst>().UpdateContent(achiList[i].achiTitle);
                rowList[i - loopCount].GetComponent<RowInst>().starImg.sprite = starImg[achiList[i].level - 1];
                if (achiList[i].isComplete) rowList[i - loopCount].GetComponent<RowInst>().stampImg.enabled = true;
                else rowList[i - loopCount].GetComponent<RowInst>().stampImg.enabled = false;
            }
        }
    }

    public void GoNextPage()
    {
        if (nowPage == maxPage) return;
        nowPage++;
        ViewPage();
    }
    public void GoPrevPage()
    {
        if (nowPage == 1) return;
        nowPage--;
        ViewPage();
    }



}

