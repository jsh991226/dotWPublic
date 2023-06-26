using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_60 : AchievementItemManager
{
    public int code = 60;   //업적 넘버링
    public string title = "캐릭터 변신! 에뮬릿 개굵"; //업적 제목
    private string require = "아이템 1번 사용"; //업적 달성 조건 문구
    private int levelNum = 1; //별 개수(레벨)
    private string clmName = "ItemUse6"; //컬럼 이름
    private int rqCount = 1; //이벤트 요구 카운트

    public AchiItem_60()
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
