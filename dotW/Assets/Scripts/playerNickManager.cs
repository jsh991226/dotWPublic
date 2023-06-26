using UnityEngine;
using Photon.Pun;
using UnityStandardAssets.Utility;
using System.Collections;
using System.Collections.Generic;

public class playerNickManager : MonoBehaviourPunCallbacks, IPunObservable
{
    public PhotonView PV; //, IPunObservable
    public TextMesh nickText;

    // Start is called before the first frame update
    void Start()
    {
        if (PV.IsMine) nickText.text = PhotonNetwork.LocalPlayer.NickName;
        PV.RPC("nickUpdate", RpcTarget.All);
    }



    [PunRPC]
    void nickUpdate()
    {
        Debug.Log("ok this is nick update : " + PV.Owner.NickName);
        nickText.text = PV.Owner.NickName;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //throw new System.NotImplementedException();
    }
}




