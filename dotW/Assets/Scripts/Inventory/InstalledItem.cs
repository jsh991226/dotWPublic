using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class InstalledItem : MonoBehaviourPunCallbacks
{
    public int itemType;
    public string itemOwner;
    public string itemName;
    public int itemOwnerID;
    public AudioClip itemVictim;


    void Start()
    {
        if (itemType < 0) itemType = 1;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player" && this.itemOwner != collision.gameObject.GetComponent<PhotonView>().Owner.NickName)
        {
            if (itemType == 1 || itemType == 2 || itemType == 3)
            {
                gameObject.transform.position = new Vector3(0, -100, 0);
                photonView.RPC("ItemEffect", RpcTarget.All, collision.gameObject.GetComponent<PhotonView>().ViewID, itemOwner, itemName, itemType);
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }



    [PunRPC]
    public void ItemEffect(int victimID, string ownerNick, string itemName, int itemType)
    {
        GameObject[] playersArray = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject plr in playersArray)
        {
            if (plr.GetComponent<PhotonView>().ViewID.Equals(victimID))
            {
                if (plr.GetComponent<playerManager>().isGod) plr.GetComponent<playerManager>().hitBox.GetComponent<HitBoxManager>().viewMyNoty("[알림] : 무적 아이템의 효과로 " + ownerNick + "(이)가 사용한 " + itemName + "을(를) 막았습니다");
                else
                {
                    plr.GetComponent<playerManager>().hitBox.GetComponent<HitBoxManager>().viewMyNoty("[알림] : " + ownerNick + "(이)가 사용한 " + itemName + "에 당했습니다!");
                    if (itemType == 1) plr.GetComponent<playerManager>().OctoEffect();
                    if (itemType == 2) plr.GetComponent<playerManager>().BananaEffect();
                    if (itemType == 3) plr.GetComponent<playerManager>().BottleEffect();
                    plr.GetComponent<AudioSource>().clip = itemVictim;
                    plr.GetComponent<AudioSource>().Play();
                }
            }
            if (plr.GetComponent<PhotonView>().ViewID.Equals(itemOwnerID))
            {
                plr.GetComponent<playerManager>().hitBox.GetComponent<HitBoxManager>().viewMyNoty("[알림] : 당신이 설치한 " + itemName + "이(가) 사용되었습니다!.");
            }
        }

     }





    [PunRPC]
    public void removeThisObject()
    {
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        PhotonNetwork.Destroy(gameObject);
    }



}
