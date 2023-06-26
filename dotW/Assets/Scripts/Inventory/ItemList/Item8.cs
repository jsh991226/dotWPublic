using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class Item8 : ItemManager
{
    
    public int itCode = 8;
    public string itName = "나 어때?";
    public string itDesc = "나한테 바로 써져!\n짜잔!! 예쁘지?\n마음에 들었으면 좋겠다!!";

    public Item8()
    {
        base.itemCode = itCode;
        base.itemName = itName;
        base.itemDesc = itDesc;
    }

    public override void itemUse(GameObject usePlayer)
    {
        usePlayer.GetComponent<playerManager>().ColorEffect();
        usePlayer.GetComponent<playerManager>().hitBox.GetComponent<HitBoxManager>().viewMyNoty("[알림] : 색 바꼈지롱 ㅋㅋㄹㅃㅃ");


    }


}
