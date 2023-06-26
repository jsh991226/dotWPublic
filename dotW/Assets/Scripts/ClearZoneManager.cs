using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ClearZoneManager : MonoBehaviourPunCallbacks
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        {
            if (other.GetComponent<PhotonView>().IsMine)
            {
                other.transform.position = new Vector3(-32.39f, 10f, 5.49f);
                GameObject HitBox = other.GetComponent<playerManager>().hitBox;
                GameObject GameManager = HitBox.GetComponent<HitBoxManager>().GameManager;
                HitBox.SetActive(false);
                GameManager.GetComponent<GameManager>().MenuTab.SetActive(true);
                GameManager.GetComponent<GameManager>().statusGUI.SetActive(false);
                GameManager.GetComponent<GameManager>().settingGUI.SetActive(false);
                GameManager.GetComponent<GameManager>().creditObj.SetActive(true);
            }

        }
    }


}
