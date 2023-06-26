using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_38 : AchievementItemManager
{
    public int code = 38;   //업적 넘버링
    public string title = "산책이나 갔다올까"; //업적 제목
    private string require = "클리어 횟수 10번"; //업적 달성 조건 문구
    private int levelNum = 3; //별 개수(레벨)
    private string clmName = "clearCount"; //컬럼 이름
    private int rqCount = 10; //이벤트 요구 카운트

    public AchiItem_38()
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