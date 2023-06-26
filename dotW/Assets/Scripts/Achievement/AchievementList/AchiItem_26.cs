using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_26 : AchievementItemManager
{
    public int code = 26;   //업적 넘버링
    public string title = "수많은 개구리 시체"; //업적 제목
    private string require = "사망 횟수 10,000번"; //업적 달성 조건 문구
    private int levelNum = 4; //별 개수(레벨)
    private string clmName = "deathCount"; //컬럼 이름
    private int rqCount = 10000; //이벤트 요구 카운트

    public AchiItem_26()
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