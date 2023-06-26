using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_9 : AchievementItemManager
{
    public int code = 9;   //업적 넘버링
    public string title = "달팽이의 응원"; //업적 제목
    private string require = "1스테이지에서 점프 100번"; //업적 달성 조건 문구
    private int levelNum = 1; //별 개수(레벨)
    private string clmName = "jumpStage1"; //컬럼 이름
    private int rqCount = 100; //이벤트 요구 카운트

    public AchiItem_9()
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