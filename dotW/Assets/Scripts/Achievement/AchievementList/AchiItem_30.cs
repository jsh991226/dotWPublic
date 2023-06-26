using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_30 : AchievementItemManager
{
    public int code = 30;   //업적 넘버링
    public string title = "고지가 코앞이었는데..!!"; //업적 제목
    private string require = "2스테이지에서 사망 횟수 300번"; //업적 달성 조건 문구
    private int levelNum = 2; //별 개수(레벨)
    private string clmName = "deathStage2"; //컬럼 이름
    private int rqCount = 300; //이벤트 요구 카운트

    public AchiItem_30()
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