using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class Item5 : ItemManager
{
    
    public int itCode = 5;
    public string itName = "앞이 잘 안보여";
    public string itDesc = "키를 누르면 맵에 나타나!\n먹으면 3초정도 어지러울거야!";

    public Item5()
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
