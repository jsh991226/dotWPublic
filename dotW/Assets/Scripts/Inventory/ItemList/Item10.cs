using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class Item10 : ItemManager
{
    
    public int itCode = 10;
    public string itName = "여기가 어디야?";
    public string itDesc = "바로 써져!\n15초 동안 안개가 생겨나\n나 구름 속에 있어!!";

    public Item10()
    {
        base.itemCode = itCode;
        base.itemName = itName;
        base.itemDesc = itDesc;
    }

    public override void itemUse(GameObject usePlayer)
    {
        Debug.Log("Using Item [ player : " + usePlayer.GetComponent<PhotonView>().Owner.NickName + " ]");
    }


}
