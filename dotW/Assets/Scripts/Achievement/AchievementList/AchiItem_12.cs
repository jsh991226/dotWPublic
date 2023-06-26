using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_12 : AchievementItemManager
{
    public int code = 12;   //업적 넘버링
    public string title = "체념한 거북이"; //업적 제목
    private string require = "2스테이지 거북이 위에서 300번 점프"; //업적 달성 조건 문구
    private int levelNum = 2; //별 개수(레벨)
    private string clmName = "jumpOnTurtle"; //컬럼 이름
    private int rqCount = 300; //이벤트 요구 카운트

    public AchiItem_12()
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