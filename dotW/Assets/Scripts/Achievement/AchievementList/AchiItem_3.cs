using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_3 : AchievementItemManager
{
    public int code = 3;   //업적 넘버링
    public string title = "나 점프 좀 해봤다"; //업적 제목
    private string require = "점프 횟수 5,000번"; //업적 달성 조건 문구
    private int levelNum = 2; //별 개수(레벨)
    private string clmName = "userJump"; //컬럼 이름
    private int rqCount = 5000; //이벤트 요구 카운트

    public AchiItem_3()
    {
        base.achiCode = code;
        base.achiTitle = title;
        base.achiRequire = require;
        base.level = levelNum;
        base.requireCount = rqCount;
        base.columnName = clmName;
    }

    public override void UpCount(int num, GameObject notifyObj)
    {
        base.UpCount(num, notifyObj);
    }

}
