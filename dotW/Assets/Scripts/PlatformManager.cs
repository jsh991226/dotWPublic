using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityStandardAssets.Utility;

public class PlatformManager : MonoBehaviourPunCallbacks
{ 
    // Start is called before the first frame update
    //public Animator animator; // Animator 속성 변수 생성
    public GameObject hbManager;
    public GameObject myInstPlayer;
    public GameObject myPlayerAchi;
    public List<AchievementItemManager> myPlayerList = new List<AchievementItemManager>();
    public GameObject myPlayerNotify;




    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "deathZone" && other.transform.tag=="Player")
        {
            if (myPlayerAchi == null) myPlayerAchi = other.transform.GetComponent<playerManager>().achiControler;
            if (myPlayerList.Count <= 0) myPlayerList = myPlayerAchi.GetComponent<AchievementManager>().achiList;
            if (myPlayerNotify == null) myPlayerNotify = other.transform.GetComponent<playerManager>().notifyObj;

            if (!myPlayerList[21].isComplete) myPlayerList[21].UpCount(1, myPlayerNotify);
            else if (!myPlayerList[22].isComplete) myPlayerList[22].UpCount(1, myPlayerNotify);
            else if (!myPlayerList[23].isComplete) myPlayerList[23].UpCount(1, myPlayerNotify);
            else if (!myPlayerList[24].isComplete) myPlayerList[24].UpCount(1, myPlayerNotify);
            else if (!myPlayerList[25].isComplete) myPlayerList[25].UpCount(1, myPlayerNotify);
            else if (!myPlayerList[26].isComplete) myPlayerList[26].UpCount(1, myPlayerNotify);

            if (other.GetComponent<playerManager>().nowStage == 1 && !myPlayerList[27].isComplete) myPlayerList[27].UpCount(1, myPlayerNotify);
            else if (other.GetComponent<playerManager>().nowStage == 1 && !myPlayerList[28].isComplete) myPlayerList[28].UpCount(1, myPlayerNotify);
            else if (other.GetComponent<playerManager>().nowStage == 1 && !myPlayerList[29].isComplete) myPlayerList[29].UpCount(1, myPlayerNotify);
            if (other.GetComponent<playerManager>().nowStage == 2 && !myPlayerList[30].isComplete) myPlayerList[30].UpCount(1, myPlayerNotify);
            else if (other.GetComponent<playerManager>().nowStage == 2 && !myPlayerList[31].isComplete) myPlayerList[31].UpCount(1, myPlayerNotify);
            else if (other.GetComponent<playerManager>().nowStage == 2 && !myPlayerList[32].isComplete) myPlayerList[32].UpCount(1, myPlayerNotify);
            if (other.GetComponent<playerManager>().nowStage == 3 && !myPlayerList[33].isComplete) myPlayerList[33].UpCount(1, myPlayerNotify);
            else if (other.GetComponent<playerManager>().nowStage == 3 && !myPlayerList[34].isComplete) myPlayerList[34].UpCount(1, myPlayerNotify);
            else if (other.GetComponent<playerManager>().nowStage == 3 && !myPlayerList[35].isComplete) myPlayerList[35].UpCount(1, myPlayerNotify);


            other.transform.position = new Vector3(-1.264f, 4.08f, -0.72f);
        }


        if (other.tag == "playerLeg")
        {
            if (other.GetComponent<playerGroundManager>().myPlayer.GetComponent<PhotonView>().IsMine)
            {
                if (Camera.main.GetComponent<SmoothFollow>().isdown == false && Camera.main.GetComponent<SmoothFollow>().isjump == true) Camera.main.GetComponent<SmoothFollow>().corJumpDown();
                if (myInstPlayer == null) myInstPlayer = other.transform.GetComponent<playerGroundManager>().myPlayer;
                myInstPlayer.GetComponent<playerManager>().playerDownRpc();
            }

        }

    }

    [System.Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (collision.transform.GetComponent<PhotonView>().IsMine)
            {
                if (myPlayerAchi == null) myPlayerAchi = collision.transform.GetComponent<playerManager>().achiControler;
                if (myPlayerList.Count<= 0) myPlayerList = myPlayerAchi.GetComponent<AchievementManager>().achiList;
                if (myPlayerNotify == null) myPlayerNotify = collision.transform.GetComponent<playerManager>().notifyObj;
                collision.transform.GetComponent<playerManager>().isJump = false;
                collision.transform.GetComponent<playerManager>().useParticle(gameObject.GetComponent<Renderer>().material.color);
                if (collision.transform.GetComponent<playerManager>().nowStage == 0 && !myPlayerList[8].isComplete) myPlayerList[8].UpCount(1, myPlayerNotify);
                if (collision.transform.GetComponent<playerManager>().nowStage == 1 && !myPlayerList[9].isComplete) myPlayerList[9].UpCount(1, myPlayerNotify);
                if (collision.transform.GetComponent<playerManager>().nowStage == 2 && !myPlayerList[12].isComplete) myPlayerList[12].UpCount(1, myPlayerNotify);
                if (collision.transform.GetComponent<playerManager>().nowStage == 3 && !myPlayerList[15].isComplete) myPlayerList[15].UpCount(1, myPlayerNotify);
                if (collision.transform.GetComponent<playerManager>().nowStage == 4 && !myPlayerList[18].isComplete) myPlayerList[15].UpCount(1, myPlayerNotify);
                if (collision.transform.GetComponent<playerManager>().nowStage == 5 && !myPlayerList[19].isComplete) myPlayerList[15].UpCount(1, myPlayerNotify);
                if (collision.transform.GetComponent<playerManager>().nowStage == 6 && !myPlayerList[20].isComplete) myPlayerList[15].UpCount(1, myPlayerNotify);
                if (gameObject.tag == "Turtle" && !myPlayerList[10].isComplete) myPlayerList[10].UpCount(1, myPlayerNotify);
                else if (gameObject.tag == "Turtle" && !myPlayerList[11].isComplete) myPlayerList[11].UpCount(1, myPlayerNotify);
                if (gameObject.tag == "Alligator" && !myPlayerList[13].isComplete) myPlayerList[13].UpCount(1, myPlayerNotify);
                else if (gameObject.tag == "Alligator" && !myPlayerList[14].isComplete) myPlayerList[14].UpCount(1, myPlayerNotify);
                if (gameObject.tag == "Book" && !myPlayerList[16].isComplete) myPlayerList[16].UpCount(1, myPlayerNotify);
                else if (gameObject.tag == "Book" && !myPlayerList[17].isComplete) myPlayerList[17].UpCount(1, myPlayerNotify);



            }

        }

    }




}
