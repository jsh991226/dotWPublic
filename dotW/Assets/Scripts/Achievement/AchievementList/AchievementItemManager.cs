using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AchievementItemManager : MonoBehaviour
{
    public int achiCode;
    public string achiTitle;
    public string achiRequire;
    public int level;
    public int requireCount;
    public string columnName;
    public bool achiComplete;
    public bool isComplete = false;
    private int resultCount;
    public virtual void UpCount(int num, GameObject notifyObj)
    {
        Thread thread = new Thread(() => BackEndGameInfo.addUserData("UserData", columnName, num));
        thread.Start();
        resultCount += num;
        CheckCount(notifyObj);

    }
    public void CheckCount(GameObject notifyObj)
    {

        Debug.Log("쓰레드 테스트 : " + resultCount);
        if (resultCount >= requireCount && !isComplete)
        {
            isComplete = true;
            notifyObj.GetComponent<NotifyManager>().setNotify("[알림] 업적을 달성하였습니다 : " + achiTitle);
        }




    }
    public void CheckCount()
    {
        var thread = new Thread(
        () =>
        {
            try
            {
                resultCount = int.Parse(BackEndGameInfo.GetData("UserData", columnName));
            }
            finally
            {
                if (resultCount >= requireCount && !isComplete)
                {
                    isComplete = true;
                }
            }
        });
        thread.Start();

    }
    public void CheckCount(int resultCount)
    {
        this.resultCount = resultCount;
        Debug.Log(columnName + " : " + resultCount);
        if (resultCount >= requireCount && !isComplete)
        {
            isComplete = true;
        }
    }

}
