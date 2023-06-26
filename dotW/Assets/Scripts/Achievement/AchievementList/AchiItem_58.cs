using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_58 : AchievementItemManager
{
    public int code = 58;   //업적 넘버링
    public string title = "백설공주가 이 사과를 먹었다면..!"; //업적 제목
    private string require = "아이템 30번 사용"; //업적 달성 조건 문구
    private int levelNum = 2; //별 개수(레벨)
    private string clmName = "itemUse5"; //컬럼 이름
    private int rqCount = 30; //이벤트 요구 카운트

    public AchiItem_58()
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