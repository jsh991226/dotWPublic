using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerSIManager : MonoBehaviourPunCallbacks
{
    public GameObject playerObj;
    private playerManager pMCom;
    public PhotonView PV;
    public SpriteRenderer Img;
    // Start is called before the first frame update
    void Start()
    {
        pMCom = playerObj.GetComponent<playerManager>();
    }

    // Update is called once per frame
    void Update()
    {
//
        //if (pMCom.changeSetting && PV.IsMine)
        //{
        //    pMCom.changeSetting = false;
       //     PV.RPC("nowPlayerSettingIcon", RpcTarget.AllBuffered);

       // }
    }

    [PunRPC]
    public void nowPlayerSettingIcon()
    {
        Debug.Log(PhotonNetwork.NickName);
        //gameObject.SetActive(pMCom.nowSettingIcon);
        Img.enabled = pMCom.nowSettingIcon;
    }
}
