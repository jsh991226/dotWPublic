using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_17 : AchievementItemManager
{
    public int code = 17;   //업적 넘버링
    public string title = "이달의 독서왕"; //업적 제목
    private string require = "4스테이지 책 위에서 100번 점프"; //업적 달성 조건 문구
    private int levelNum = 1; //별 개수(레벨)
    private string clmName = "jumpOnBook"; //컬럼 이름
    private int rqCount = 100; //이벤트 요구 카운트

    public AchiItem_17()
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