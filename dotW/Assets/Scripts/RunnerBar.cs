using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class RunnerBar : MonoBehaviourPunCallbacks
{
    public int myBoxNum;
    public int myStageNum;
    public Vector3 myPos;
    public GameObject runnerGroup;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        {
            if (other.transform.GetComponent<PhotonView>().IsMine)
            {
                runnerGroup.GetComponent<RunnerBarManager>().MyCharMove(myPos);

            }
        }

    }

}
