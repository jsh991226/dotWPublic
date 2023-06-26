using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class Item9 : ItemManager
{
    
    public int itCode = 9;
    public string itName = "나는 안죽어!";
    public string itDesc = "가지고 있는 아이템이야!\n내가 죽을 위기에 처하면 3초동안 무적이 발동될거야";

    public Item9()
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
