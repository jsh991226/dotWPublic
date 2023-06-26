using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_24 : AchievementItemManager
{
    public int code = 24;   //업적 넘버링
    public string title = "와! 태초마을이야!"; //업적 제목
    private string require = "사망 횟수 500번"; //업적 달성 조건 문구
    private int levelNum = 2; //별 개수(레벨)
    private string clmName = "deathCount"; //컬럼 이름
    private int rqCount = 500; //이벤트 요구 카운트

    public AchiItem_24()
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