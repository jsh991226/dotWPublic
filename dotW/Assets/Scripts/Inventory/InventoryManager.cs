using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class InventoryManager : MonoBehaviourPunCallbacks
{
    public List<GameObject> playerItemSlot = new List<GameObject>();
    public ItemData<ItemManager> playerInvST = new ItemData<ItemManager>();
    public Texture emptyImg;
    public List<Texture> invItemIcon = new List<Texture>();
    public GameObject nowPlayer;
    public AudioSource audioComp;
    public AudioClip itemUseSound;


    void Start()
    {
        playerItemSlot.Add(GameObject.Find("InvItem_1"));
        playerItemSlot.Add(GameObject.Find("InvItem_2"));
        playerItemSlot.Add(GameObject.Find("InvItem_3"));
        if (playerInvST.Count() > 0)
        {
            playerInvRefresh();
        }
    }
    public bool addItem(ItemManager item)
    {
        if (playerInvST.Count() < 3)
        {
            playerInvST.Append(item);
            playerInvRefresh();
            string ic;
            if (item.itemCode < 10) ic = "0" + item.itemCode;
            else ic = item.itemCode + "";
            Thread thread0 = new Thread(() => BackEndGameInfo.addUserData("UserData", "userItemEat" + ic, 1));
            thread0.Start();
            return true;
        }
        else
        {
            return false;
        }

    }
    void Update()
    {
        int nowUseItem = 999;
        if (Input.GetKeyDown(KeyCode.Alpha1)) nowUseItem = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) nowUseItem = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3)) nowUseItem = 2;

        if (playerInvST.Count() > nowUseItem)
        {
            audioComp.clip = itemUseSound;
            audioComp.Play();
            playerInvST.Get(nowUseItem).itemUse(nowPlayer);
            string ic;
            if (playerInvST.Get(nowUseItem).itemCode < 10) ic = "0" + playerInvST.Get(nowUseItem).itemCode;
            else ic = playerInvST.Get(nowUseItem).itemCode + "";
            Thread thread1 = new Thread(() => BackEndGameInfo.addUserData("UserData", "userItemUse" + ic, 1));
            thread1.Start();
            playerInvST.RemoveAt(nowUseItem);
            playerInvRefresh();
        }



    }
    public void playerInvRefresh()
    {

        for (int i = 0; i < playerItemSlot.Count; i++)
        {
            if (i < playerInvST.Count())
            {
                ItemManager tempItem = playerInvST.Get(i);
                playerItemSlot[i].GetComponent<RawImage>().texture = invItemIcon[tempItem.itemCode - 1];
                playerItemSlot[i].GetComponent<ItemDescManager>().itemNameString = tempItem.itemName;
                playerItemSlot[i].GetComponent<ItemDescManager>().itemDescString = tempItem.itemDesc;
            }
            else
            {
                playerItemSlot[i].GetComponent<RawImage>().texture = emptyImg;
                playerItemSlot[i].GetComponent<ItemDescManager>().itemNameString = "";
                playerItemSlot[i].GetComponent<ItemDescManager>().itemDescString = "";
            }

        }

    }


}
