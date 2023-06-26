using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_36 : AchievementItemManager
{
    public int code = 36;   //업적 넘버링
    public string title = "사실 나는 맨홀이 좋아"; //업적 제목
    private string require = "4스테이지에서 사망 횟수 100번"; //업적 달성 조건 문구
    private int levelNum = 2; //별 개수(레벨)
    private string clmName = "deathStage4"; //컬럼 이름
    private int rqCount = 100; //이벤트 요구 카운트

    public AchiItem_36()
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
