using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class Item1 : ItemManager
{
    
    public int itCode = 1;
    public string itName = "동글동글 문어";
    public string itDesc = "키를 누르면 맵에 나타나! \n 다른 애가 먹으면 3초동안 화면이 까매질껄??";

    public Item1()
    {
        base.itemCode = itCode;
        base.itemName = itName;
        base.itemDesc = itDesc;
    }

    public override void itemUse(GameObject usePlayer)
    {
        Debug.Log("Using Item [ player : " + usePlayer.GetComponent<PhotonView>().Owner.NickName + " ]");

        var spawnedItem = PhotonNetwork.Instantiate("ItemModelOcto", usePlayer.transform.position, Quaternion.identity, 0);
        spawnedItem.GetComponent<InstalledItem>().itemOwner = usePlayer.GetComponent<PhotonView>().Owner.NickName;
        spawnedItem.GetComponent<InstalledItem>().itemType = itCode;
        spawnedItem.GetComponent<InstalledItem>().itemName = itName;
        spawnedItem.GetComponent<InstalledItem>().itemOwnerID = usePlayer.GetComponent<PhotonView>().ViewID;
        //List<AchievementItemManager> myPlayerList = usePlayer.GetComponent<playerManager>().achiControler.GetComponent<AchievementManager>().achiList;
        //GameObject myPlayerNotify = usePlayer.GetComponent<playerManager>().notifyObj;
        //if (!myPlayerList[21].isComplete) myPlayerList[21].UpCount(1, myPlayerNotify);
    }



}
