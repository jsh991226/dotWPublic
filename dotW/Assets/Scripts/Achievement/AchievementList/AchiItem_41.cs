using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_41 : AchievementItemManager
{
    public int code = 41;   //업적 넘버링
    public string title = "귀여움 속 시커먼 진실"; //업적 제목
    private string require = "아이템 5번 피격"; //업적 달성 조건 문구
    private int levelNum = 1; //별 개수(레벨)
    private string clmName = "itemVictim1"; //컬럼 이름
    private int rqCount = 5; //이벤트 요구 카운트

    public AchiItem_41()
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