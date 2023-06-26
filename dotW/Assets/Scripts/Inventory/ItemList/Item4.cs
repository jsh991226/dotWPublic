using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class Item4 : ItemManager
{
    
    public int itCode = 4;
    public string itName = "다 덤벼!";
    public string itDesc = "나한테 바로 써져!\n3초동안 무적상태가 돼\n 아무도 날 막지 못할거야!!";

    public Item4()
    {
        base.itemCode = itCode;
        base.itemName = itName;
        base.itemDesc = itDesc;
    }
    
    public override void itemUse(GameObject usePlayer)
    {
        usePlayer.GetComponent<playerManager>().GodEffect();
        usePlayer.GetComponent<playerManager>().hitBox.GetComponent<HitBoxManager>().viewMyNoty("[알림] : 지금부터 3초동안 아이템의 효과를 받지 않습니다");
    }


}
