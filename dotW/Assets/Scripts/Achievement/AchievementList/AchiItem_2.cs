using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiItem_2 : AchievementItemManager
{
    public int code = 2;   //업적 넘버링
    public string title = "초보 댄서"; //업적 제목
    private string require = "점프 횟수 1,000번"; //업적 달성 조건 문구
    private int levelNum = 1; //별 개수(레벨)
    private string clmName = "userJump"; //컬럼 이름
    private int rqCount = 1000; //이벤트 요구 카운트

    public AchiItem_2()
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
