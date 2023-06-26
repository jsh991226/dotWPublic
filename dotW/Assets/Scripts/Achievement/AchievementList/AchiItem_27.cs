using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_27 : AchievementItemManager
{
    public int code = 27;   //업적 넘버링
    public string title = "환생 시켜주세요"; //업적 제목
    private string require = "사망 횟수 1,000,000번"; //업적 달성 조건 문구
    private int levelNum = 5; //별 개수(레벨)
    private string clmName = "deathCount"; //컬럼 이름
    private int rqCount = 1000000; //이벤트 요구 카운트

    public AchiItem_27()
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