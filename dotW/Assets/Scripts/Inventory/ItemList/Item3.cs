using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class Item3 : ItemManager
{
    
    public int itCode = 3;
    public string itName = "밥 먹는 손은 왼손?";
    public string itDesc = "키를 누르면 맵에 나타나! \n 먹으면 5초동안 오른쪽 왼쪽이 바뀐대 \n 그러면 나는 왼손으로 밥 먹으면 되나?";

    public Item3()
    {
        base.itemCode = itCode;
        base.itemName = itName;
        base.itemDesc = itDesc;
    }

    public override void itemUse(GameObject usePlayer)
    {
        var spawnedItem = PhotonNetwork.Instantiate("ItemModelBottle", usePlayer.transform.position, Quaternion.identity, 0);
        spawnedItem.GetComponent<InstalledItem>().itemOwner = usePlayer.GetComponent<PhotonView>().Owner.NickName;
        spawnedItem.GetComponent<InstalledItem>().itemType = itCode;
        spawnedItem.GetComponent<InstalledItem>().itemName = itName;
        spawnedItem.GetComponent<InstalledItem>().itemOwnerID = usePlayer.GetComponent<PhotonView>().ViewID;
    }


}
