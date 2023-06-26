using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_56 : AchievementItemManager
{
    public int code = 56;   //업적 넘버링
    public string title = "10분동안 무적이었던 자"; //업적 제목
    private string require = "아이템 200번 사용"; //업적 달성 조건 문구
    private int levelNum = 3; //별 개수(레벨)
    private string clmName = "ItemUse4"; //컬럼 이름
    private int rqCount = 200; //이벤트 요구 카운트

    public AchiItem_56()
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