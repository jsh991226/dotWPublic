using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_23 : AchievementItemManager
{
    public int code = 23;   //업적 넘버링
    public string title = "생각보다 어려운데?"; //업적 제목
    private string require = "사망 횟수 100번"; //업적 달성 조건 문구
    private int levelNum = 1; //별 개수(레벨)
    private string clmName = "deathCount"; //컬럼 이름
    private int rqCount = 100; //이벤트 요구 카운트

    public AchiItem_23()
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