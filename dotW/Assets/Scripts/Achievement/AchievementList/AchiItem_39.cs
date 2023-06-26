using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_39 : AchievementItemManager
{
    public int code = 39;   //업적 넘버링
    public string title = "우물 밖 개구리"; //업적 제목
    private string require = "클리어 횟수 100번"; //업적 달성 조건 문구
    private int levelNum = 4; //별 개수(레벨)
    private string clmName = "clearCount"; //컬럼 이름
    private int rqCount = 100; //이벤트 요구 카운트

    public AchiItem_39()
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