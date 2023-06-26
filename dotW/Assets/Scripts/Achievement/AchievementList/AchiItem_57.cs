using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_57 : AchievementItemManager
{
    public int code = 57;   //업적 넘버링
    public string title = "혈액순환에 도움이 됩니다"; //업적 제목
    private string require = "아이템 1번 사용"; //업적 달성 조건 문구
    private int levelNum = 1; //별 개수(레벨)
    private string clmName = "itemUse5"; //컬럼 이름
    private int rqCount = 1; //이벤트 요구 카운트

    public AchiItem_57()
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