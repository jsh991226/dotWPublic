using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_59 : AchievementItemManager
{
    public int code = 59;   //업적 넘버링
    public string title = "모래시계놀이 할 사람??"; //업적 제목
    private string require = "아이템 300번 사용"; //업적 달성 조건 문구
    private int levelNum = 3; //별 개수(레벨)
    private string clmName = "itemUse5"; //컬럼 이름
    private int rqCount = 300; //이벤트 요구 카운트

    public AchiItem_59()
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