using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class Item7 : ItemManager
{
    
    public int itCode = 7;
    public string itName = "물구나무서기를 보여주지";
    public string itDesc = "나한테 바로 써져!\n먹으면 머리로 뛰어다녀줄께!";

    public Item7()
    {
        base.itemCode = itCode;
        base.itemName = itName;
        base.itemDesc = itDesc;
    }

    public override void itemUse(GameObject usePlayer)
    {
        usePlayer.GetComponent<playerManager>().FlipEffect();
        usePlayer.GetComponent<playerManager>().hitBox.GetComponent<HitBoxManager>().viewMyNoty("[알림] : 뒤집힙니당~! 다시주워서 쓰세용~!");
    }


}
