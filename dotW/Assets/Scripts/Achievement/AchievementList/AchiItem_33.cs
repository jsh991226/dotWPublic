using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_33 : AchievementItemManager
{
    public int code = 33;   //업적 넘버링
    public string title = "B를 눌러서 개굴닌자로 진화 취소"; //업적 제목
    private string require = "3스테이지에서 사망 횟수 150번"; //업적 달성 조건 문구
    private int levelNum = 2; //별 개수(레벨)
    private string clmName = "deathStage3"; //컬럼 이름
    private int rqCount = 150; //이벤트 요구 카운트

    public AchiItem_33()
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