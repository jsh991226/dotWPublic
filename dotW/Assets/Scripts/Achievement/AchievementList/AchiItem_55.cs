using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_55 : AchievementItemManager
{
    public int code = 55;   //업적 넘버링
    public string title = "나는 아이템 알러지 개구리"; //업적 제목
    private string require = "무적 상태에서 막은 아이템 300개"; //업적 달성 조건 문구
    private int levelNum = 3; //별 개수(레벨)
    private string clmName = "itemProtect"; //컬럼 이름
    private int rqCount = 300; //이벤트 요구 카운트

    public AchiItem_55()
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