using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class Item2 : ItemManager
{
    
    public int itCode = 2;
    public string itName = "바나나 껍질은 맛없어";
    public string itDesc = "키를 누르면 맵에 나타나! \n 뒤로 가고 싶으면 밟아두 돼";

    public Item2()
    {
        base.itemCode = itCode;
        base.itemName = itName;
        base.itemDesc = itDesc;
    }

    public override void itemUse(GameObject usePlayer)
    {
        var spawnedItem = PhotonNetwork.Instantiate("ItemModelBanana", usePlayer.transform.position, Quaternion.identity, 0);
        spawnedItem.GetComponent<InstalledItem>().itemOwner = usePlayer.GetComponent<PhotonView>().Owner.NickName;
        spawnedItem.GetComponent<InstalledItem>().itemType = itCode;
        spawnedItem.GetComponent<InstalledItem>().itemName = itName;
        spawnedItem.GetComponent<InstalledItem>().itemOwnerID = usePlayer.GetComponent<PhotonView>().ViewID;

    }


}
