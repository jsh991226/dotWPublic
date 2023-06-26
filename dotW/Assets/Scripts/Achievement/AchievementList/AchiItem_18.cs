using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_18 : AchievementItemManager
{
    public int code = 18;   //업적 넘버링
    public string title = "베스트셀러!"; //업적 제목
    private string require = "4스테이지 책 위에서 300번 점프"; //업적 달성 조건 문구
    private int levelNum = 2; //별 개수(레벨)
    private string clmName = "jumpOnBook"; //컬럼 이름
    private int rqCount = 300; //이벤트 요구 카운트

    public AchiItem_18()
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