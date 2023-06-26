using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class ttInventoryManager : MonoBehaviour
{
    public List<ItemManagerTuto> playerInv = new List<ItemManagerTuto>();
    public List<GameObject> playerItemSlot = new List<GameObject>();
    public Texture emptyImg;
    public List<Texture> invItemIcon = new List<Texture>();
    public GameObject nowPlayer;


    void Start()
    {

        if (playerInv.Count > 0)
        {
            playerInvRefresh();
        }
    }
    public bool addItem(ItemManagerTuto item)
    {
        if (playerInv.Count < 3)
        {
            playerInv.Add(item);
            playerInvRefresh();
            string ic;
            if (item.itemCode < 10) ic = "0" + item.itemCode;
            else ic = item.itemCode + "";
            return true;
        }
        else
        {
            return false;
        }

    }

    public void playerInvRefresh()
    {
        for ( int i = 0; i < playerItemSlot.Count; i++)
        {
            if (i < playerInv.Count)
            {
                playerItemSlot[i].GetComponent<RawImage>().texture = invItemIcon[(playerInv[i].itemCode - 1)];
                playerItemSlot[i].GetComponent<ItemDescManager>().itemNameString = playerInv[i].itemName;
                playerItemSlot[i].GetComponent<ItemDescManager>().itemDescString = playerInv[i].itemDesc;
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
