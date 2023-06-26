using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_7 : AchievementItemManager
{
    public int code = 7;   //업적 넘버링
    public string title = "식사는 하시나요?"; //업적 제목
    private string require = "점프 횟수 50,000,000번"; //업적 달성 조건 문구
    private int levelNum = 4; //별 개수(레벨)
    private string clmName = "userJump"; //컬럼 이름
    private int rqCount = 50000000; //이벤트 요구 카운트

    public AchiItem_7()
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