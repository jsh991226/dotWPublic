using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class playerMaterialManager : MonoBehaviourPunCallbacks, IPunObservable
{
    public byte codeR;
    public byte codeG;
    public byte codeB;
    public Material tempMet;

    private void Awake()
    {
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //통신을 보내는
        Debug.Log("gogogo");
        if (stream.IsWriting)
        {
            stream.SendNext(gameObject.GetComponent<Renderer>().material.color.r);
            stream.SendNext(gameObject.GetComponent<Renderer>().material.color.g);
            stream.SendNext(gameObject.GetComponent<Renderer>().material.color.b);
        }
        //클론이 통신을 받는 
        else
        {
            codeR = Convert.ToByte(stream.ReceiveNext());
            codeG = Convert.ToByte(stream.ReceiveNext());
            codeB = Convert.ToByte(stream.ReceiveNext());
        }
    }
    private void Update()
    {
        if (photonView.IsMine != false && codeR > 0)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color32(codeR, codeG, codeB, 0);
            Debug.Log("얘 나 아님 : " + PhotonNetwork.LocalPlayer.NickName);

        }

        /*if (photonView.IsMine)
        {
            tempMet.color = new Color(codeR, codeG, codeB);
            //Debug.Log("currMat " + currMat);
            if (codeR >= 0) gameObject.GetComponent<Renderer>().material = tempMet;
        } else
        {
            //if (codeR >= 0) gameObject.GetComponent<Renderer>().material = tempMet;

        }*/
    }
}
