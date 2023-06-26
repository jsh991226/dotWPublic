using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_15 : AchievementItemManager
{
    public int code = 15;   //업적 넘버링
    public string title = "친절한 안마사"; //업적 제목
    private string require = "3스테이지 악어 위에서 300번 점프"; //업적 달성 조건 문구
    private int levelNum = 2; //별 개수(레벨)
    private string clmName = "jumpOnAlligator"; //컬럼 이름
    private int rqCount = 300; //이벤트 요구 카운트

    public AchiItem_15()
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
