using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class RunnerAnotherIcon : MonoBehaviourPunCallbacks, IPunObservable
{
    private Transform tr;
    private Vector3 currPos;
    public PhotonView PV;

    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (tr == null) return;
        if (stream.IsWriting)
        {
            stream.SendNext(tr.position);
        }
        else
        {
            currPos = (Vector3)stream.ReceiveNext();
        }
    }
    void FixedUpdate()
    {
        if (tr == null) return;
        if (PV.IsMine)
        {
        }
        else
        {
            if ((tr.position - currPos).sqrMagnitude >= 10.0f * 10.0f)
            {
                tr.position = currPos;
            }
            else
            {
                tr.position = Vector3.Lerp(tr.position, currPos, Time.deltaTime * 10.0f);
            }
        }

    }

}
