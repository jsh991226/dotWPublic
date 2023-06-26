using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class Item6 : ItemManager
{
    
    public int itCode = 6;
    public string itName = "지금은 잘 시간!";
    public string itDesc = "키를 누르면 맵에 나타나!\n먹으면 10초동안 잘 수 있대! \n다른 친구가 깨우면 바로 일어나나봐";

    public Item6()
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
