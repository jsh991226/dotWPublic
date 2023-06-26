using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_37 : AchievementItemManager
{
    public int code = 37;   //업적 넘버링
    public string title = "다시 우물 속으로!"; //업적 제목
    private string require = "클리어 횟수 1번"; //업적 달성 조건 문구
    private int levelNum = 2; //별 개수(레벨)
    private string clmName = "clearCount"; //컬럼 이름
    private int rqCount = 1; //이벤트 요구 카운트

    public AchiItem_37()
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