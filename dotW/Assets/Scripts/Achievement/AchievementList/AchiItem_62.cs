using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_62 : AchievementItemManager
{
    public int code = 62;   //업적 넘버링
    public string title = "개구리 도감 달성률 100%"; //업적 제목
    private string require = "아이템 300번 사용"; //업적 달성 조건 문구
    private int levelNum = 3; //별 개수(레벨)
    private string clmName = "ItemUse6"; //컬럼 이름
    private int rqCount = 300; //이벤트 요구 카운트

    public AchiItem_62()
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
