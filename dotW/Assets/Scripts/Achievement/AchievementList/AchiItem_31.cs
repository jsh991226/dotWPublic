using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_31 : AchievementItemManager
{
    public int code = 31;   //업적 넘버링
    public string title = "높은곳은 무서워요"; //업적 제목
    private string require = "3스테이지에서 사망 횟수 10번"; //업적 달성 조건 문구
    private int levelNum = 1; //별 개수(레벨)
    private string clmName = "deathStage3"; //컬럼 이름
    private int rqCount = 10; //이벤트 요구 카운트

    public AchiItem_31()
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