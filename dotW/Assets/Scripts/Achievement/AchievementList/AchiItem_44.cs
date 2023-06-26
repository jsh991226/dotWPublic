using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_44 : AchievementItemManager
{
    public int code = 44;   //업적 넘버링
    public string title = "문어 맛좀 봐라!"; //업적 제목
    private string require = "아이템 500번 적중"; //업적 달성 조건 문구
    private int levelNum = 4; //별 개수(레벨)
    private string clmName = "itemAttack1"; //컬럼 이름
    private int rqCount = 500; //이벤트 요구 카운트

    public AchiItem_44()
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