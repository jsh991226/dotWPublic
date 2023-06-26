using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_51 : AchievementItemManager
{
    public int code = 51;   //업적 넘버링
    public string title = "술이 달게 느껴지면 어른이래"; //업적 제목
    private string require = "아이템 1번 적중"; //업적 달성 조건 문구
    private int levelNum = 1; //별 개수(레벨)
    private string clmName = "itemAttack3"; //컬럼 이름
    private int rqCount = 1; //이벤트 요구 카운트

    public AchiItem_51()
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
