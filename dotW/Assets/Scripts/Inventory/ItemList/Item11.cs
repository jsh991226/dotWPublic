using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class Item11 : ItemManager
{
    
    public int itCode = 11;
    public string itName = "나 데리고 가";
    public string itDesc = "나한테 바로 써져!\n나보다 랭킹이 하나 더 높은 사람한테 어부바 할거야! \n 한번 더 쓰면 풀려나 나랑 같이 갈래?";

    public Item11()
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
