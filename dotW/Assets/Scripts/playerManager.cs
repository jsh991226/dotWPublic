
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityStandardAssets.Utility;
using System.Threading;
using UnityEngine.UI;

public class playerManager : MonoBehaviourPunCallbacks, IPunObservable
{


    public float speed = 3.0f;
    private Transform tr;
    public PhotonView PV;
    public bool isJump;
    public Rigidbody rigidbody;
    //클론이 통신을 받는 변수 설정
    private Vector3 currPos;
    private Quaternion currRot;
    private Quaternion currModelRot;
    public Animator animator; // Animator 속성 변수 생성
    public GameObject hitBox = null;
    public GameObject playerModel;
    public GameObject myCamera;
    public GameObject TargetStm;
    public GameObject TargetBody;
    public GameObject Targetcheek;
    public Material mettemp;
    public GameObject nowSetting;
    public GameObject achiControler;
    public ParticleSystem particleObj;
    public AnimationClip jumpAnim;
    public AnimationClip downAnim;
    private Animation playerAnim;
    public bool nowSettingIcon;
    private int animationSV = 0;
    private int currAniSV;
    private bool currSetting;
    private bool nowPart = false;
    public ParticleSystem playerParticle;
    public ParticleSystem footParticle;
    private bool isAlchohol = false;
    public bool isGod = false;
    private bool isFlip = false;
    public GameObject notifyObj;
    public int nowStage = 0;
    public GameObject myAnotherIcon;
    public GameObject runnerManager;




    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //통신을 보내는 
        if (stream.IsWriting)
        {
            stream.SendNext(tr.position);
            stream.SendNext(tr.rotation);
            stream.SendNext(playerModel.transform.rotation);
            stream.SendNext(animationSV);
            stream.SendNext(nowSettingIcon);
            stream.SendNext(nowPart);
        }

        //클론이 통신을 받는 
        else
        {
            currPos = (Vector3)stream.ReceiveNext();
            currRot = (Quaternion)stream.ReceiveNext();
            currModelRot = (Quaternion)stream.ReceiveNext();
            currAniSV = (int)stream.ReceiveNext();
            currSetting = (bool)stream.ReceiveNext();

        }
    }
    public void SetMyIcon()
    {
        GameObject myCharIcon = runnerManager.GetComponent<RunnerBarManager>().myCharIcon;
        myAnotherIcon = PhotonNetwork.Instantiate("UserAnother", myCharIcon.transform.position, myCharIcon.transform.rotation, 0);
        runnerManager.GetComponent<RunnerBarManager>().myAnotherIcon = myAnotherIcon;
    }


    void Start()
    {
        tr = GetComponent<Transform>();
        isJump = false;

        //animator = GetComponent<Animator>(); // animator 변수를 Player의 Animator 속성으로 초기화
        if (PV.IsMine) Camera.main.GetComponent<SmoothFollow>().target = tr.Find("CamPivot").transform;
        if(PV.IsMine)
        {
            playerAnim = playerModel.GetComponent<Animation>();

        }


    }

    public void playerColorchange(Color Stomach, Color Cheek, Color Body)
    {
        if (PV.IsMine)
        {

            float sR = Stomach.r;
            float sG = Stomach.g;
            float sB = Stomach.b;
            float cR = Cheek.r;
            float cG = Cheek.g;
            float cB = Cheek.b;
            float bR = Body.r;
            float bG = Body.g;
            float bB = Body.b;
            PV.RPC("playerColorUpdate", RpcTarget.AllBuffered, sR, sG, sB, cR, cG, cB, bR, bG, bB);
            string colorTemp = bR + ":" + bG + ":" + bB + "-" + sR + ":" + sG + ":" + sB + "-" + cR + ":" + cG + ":" + cB;
            BackEndGameInfo.updateUserData("UserData", "customColor", colorTemp);

        }

    }
    public Color getRandomColor()
    {
        var rng = new System.Random();
        var rdr = (rng.Next() % 1000) / 1000.0f;
        var rdg = (rng.Next() % 1000) / 1000.0f;
        var rdb = (rng.Next() % 1000) / 1000.0f;
        return new Color(rdr, rdg, rdb);
    }





    public void playerSettingIconToggle(bool status)
    {
        if (PV.IsMine)
        {
            Debug.Log("변경 호출");
            nowSettingIcon = status;
            nowSetting.SetActive(status);
        }

    }





    public void playerDownRpc()
    {
        PV.RPC("playerDownAnim", RpcTarget.AllBuffered);
    }




    [PunRPC]
    public void playerJumpAnim()
    {
        if (PV.IsMine)
        {
            animationSV = 1;
            playerAnim.clip = jumpAnim;
            playerAnim.Play();
        }

    }
    [PunRPC]
    public void playerDownAnim()
    {
        if (PV.IsMine)
        {
            animationSV = 2;
            playerAnim.clip = downAnim;
            playerAnim.Play();
        }
    }

    [System.Obsolete]
    public void useParticle(Color footColor)
    {
        float sR = footColor.r;
        float sG = footColor.g;
        float sB = footColor.b;
        string colorTemp = sR + ":" + sG + ":" + sB;
        PV.RPC("setUseParticle", RpcTarget.AllBuffered, gameObject.transform.position, colorTemp);
    }

    [PunRPC]
    [System.Obsolete]
    public void setUseParticle(Vector3 setLoc, string footColor)
    {
        string[] colorSplit = footColor.Split(':');

        float bR = (float.Parse(colorSplit[0]));
        float bG = (float.Parse(colorSplit[1]));
        float bB = (float.Parse(colorSplit[2]));
        //usePlayer.GetComponent<playerManager>().playerParticle.Play();
        setLoc.y += 0.1f;
        ParticleSystem test = Instantiate(footParticle, setLoc, Quaternion.identity);
        test.startColor = new Color(bR, bG, bB);
        test.Play();

    }
    public void SetParent()
    {
        if (PV.IsMine)
        {
            PV.RPC("SetParentRPC", RpcTarget.AllBuffered);
        }

    }


    [PunRPC]
    public void SetParentRPC()
    {
        GameObject.Find("UserAnother(Clone)").transform.parent = hitBox.GetComponent<HitBoxManager>().runnerManager.GetComponent<RunnerBarManager>().anotherCharGroup.transform;
        Debug.Log("부모 설정 ㅋㅋ");

    }






    public void joinCustomColor(string colorStr)
    {
        Debug.Log("joinCustomColor call");

        float bR, bG, bB;
        float sR, sG, sB;
        float cR, cG, cB;
        string[] colorSplit = colorStr.Split(':', '-');
        bR = (float.Parse(colorSplit[0]));
        bG = (float.Parse(colorSplit[1]));
        bB = (float.Parse(colorSplit[2]));
        sR = (float.Parse(colorSplit[3]));
        sG = (float.Parse(colorSplit[4]));
        sB = (float.Parse(colorSplit[5]));
        cR = (float.Parse(colorSplit[6]));
        cG = (float.Parse(colorSplit[7]));
        cB = (float.Parse(colorSplit[8]));
        string colorTemp = "Color Call : " + bR + ":" + bG + ":" + bB + "-" + sR + ":" + sG + ":" + sB + "-" + cR + ":" + cG + ":" + cB;
        Debug.Log(colorTemp);
        PV.RPC("playerColorUpdate", RpcTarget.AllBuffered, sR, sG, sB, cR, cG, cB, bR, bG, bB);
    }



    [PunRPC]
    [System.Obsolete]
    void playerColorUpdate(float sR, float sG, float sB, float cR, float cG, float cB, float bR, float bG, float bB)
    {
        Transform frogModel = gameObject.transform.FindChild("FrogModel");
        Transform playerStomach = frogModel.FindChild("PrefabStomach");
        Transform playerCheek = frogModel.FindChild("PrefabCheek");
        Transform playerBody = frogModel.FindChild("PrefabBody");
        playerStomach.GetComponent<Renderer>().material.SetColor("_Color", new Color(sR, sG, sB));
        playerCheek.GetComponent<Renderer>().material.SetColor("_Color", new Color(cR, cG, cB));
        playerBody.GetComponent<Renderer>().material.SetColor("_Color", new Color(bR, bG, bB));
    }

    public float getFlipEuler()
    {
        if (isFlip) return 180f;
        else return 0f;
    }

    public void goJump(float jumpLv, string key) {
        if (isJump == false)
        {
            isJump = true; Vector3 getVel = new Vector3();
            if (isAlchohol)
            {
                if (key == "left") key = "right";
                else key = "left";
            }
            if (key == "left")
            {
                getVel = new Vector3(-0.6f * (jumpLv / 100), 0.7f*(jumpLv/100), 0.0f) * speed;
                playerModel.transform.rotation = Quaternion.Euler(0, 190f, getFlipEuler());
            }
            if (key == "right")
            {
                getVel = new Vector3(0.6f * (jumpLv / 100), 0.7f * (jumpLv / 100), 0.0f) * speed;
                playerModel.transform.rotation = Quaternion.Euler(0, 170f, getFlipEuler());
            }
            if (key == "space")
            {
                getVel = new Vector3(0.0f, 0.7f * (jumpLv / 100), 0.0f) * speed;
            }
            rigidbody.velocity = getVel;

            PV.RPC("playerJumpAnim", RpcTarget.AllBuffered);
            if (Camera.main.GetComponent<SmoothFollow>().isjump == false && Camera.main.GetComponent<SmoothFollow>().isdown == false) Camera.main.GetComponent<SmoothFollow>().corJumpUp();
            if (!achiControler.GetComponent<AchievementManager>().achiList[0].isComplete) achiControler.GetComponent<AchievementManager>().achiList[0].UpCount(1, notifyObj);
            else if (!achiControler.GetComponent<AchievementManager>().achiList[1].isComplete) achiControler.GetComponent<AchievementManager>().achiList[1].UpCount(1, notifyObj);
            else if (!achiControler.GetComponent<AchievementManager>().achiList[2].isComplete) achiControler.GetComponent<AchievementManager>().achiList[2].UpCount(1, notifyObj);
            else if (!achiControler.GetComponent<AchievementManager>().achiList[3].isComplete) achiControler.GetComponent<AchievementManager>().achiList[3].UpCount(1, notifyObj);
            else if (!achiControler.GetComponent<AchievementManager>().achiList[4].isComplete) achiControler.GetComponent<AchievementManager>().achiList[4].UpCount(1, notifyObj);
            else if (!achiControler.GetComponent<AchievementManager>().achiList[5].isComplete) achiControler.GetComponent<AchievementManager>().achiList[5].UpCount(1, notifyObj);
            else if (!achiControler.GetComponent<AchievementManager>().achiList[6].isComplete) achiControler.GetComponent<AchievementManager>().achiList[6].UpCount(1, notifyObj);
            else if (!achiControler.GetComponent<AchievementManager>().achiList[7].isComplete) achiControler.GetComponent<AchievementManager>().achiList[7].UpCount(1, notifyObj);

        }



    }

    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                Vector3 getVel = new Vector3(0.6f, 0.7f, 0.0f) * speed;
                rigidbody.velocity = getVel;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Vector3 getVel = new Vector3(-0.6f, 0.7f, 0.0f) * speed;
                rigidbody.velocity = getVel;
            }
        }
    }

    [System.Obsolete]
    void FixedUpdate()
    {


   



        if (photonView.IsMine)
        {
            if (rigidbody.velocity.y < -5)
            {
                Vector3 speedTemp = new Vector3(0, -5, 0);
                rigidbody.velocity = speedTemp;
            }
            GameObject[] tempobj = GameObject.FindGameObjectsWithTag("AnotherIcon");
            foreach (GameObject ob in tempobj)
            {
                if (ob.transform.parent != hitBox.GetComponent<HitBoxManager>().runnerManager.GetComponent<RunnerBarManager>().anotherCharGroup.transform)
                ob.transform.parent = hitBox.GetComponent<HitBoxManager>().runnerManager.GetComponent<RunnerBarManager>().anotherCharGroup.transform;
            }




        }
        else
        {
            if ((tr.position - currPos).sqrMagnitude >= 10.0f * 10.0f)
            {
                tr.position = currPos;
                tr.rotation = currRot;
                playerModel.transform.rotation = currModelRot;
               // myAnotherIcon.transform.position = iconCurrPos;
            }
            else
            {
                //myAnotherIcon.transform.position = Vector3.Lerp(myAnotherIcon.transform.position, iconCurrPos, Time.deltaTime * 10.0f);
                tr.position = Vector3.Lerp(tr.position, currPos, Time.deltaTime * 10.0f);
                tr.rotation = Quaternion.Slerp(tr.rotation, currRot, Time.deltaTime * 10.0f);
                playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, currModelRot, Time.deltaTime * 10.0f);
                gameObject.GetComponent<playerManager>().nowSetting.SetActive(currSetting);
                if ( currAniSV == 1 && playerModel.GetComponent<Animation>().clip != jumpAnim)
                {
                    playerModel.GetComponent<Animation>().clip = jumpAnim;
                    playerModel.GetComponent<Animation>().Play();
                    currAniSV = 0;
                }
                if (currAniSV == 2 && playerModel.GetComponent<Animation>().clip != downAnim)
                {
                    playerModel.GetComponent<Animation>().clip = downAnim;
                    playerModel.GetComponent<Animation>().Play();
                    currAniSV = 0;
                }


            }
        }

    }


    public void ColorEffect()
    {
        if (PV.IsMine)
        {
            Color rdc = getRandomColor();
            PV.RPC("playerColorUpdate", RpcTarget.AllBuffered, rdc.r, rdc.g, rdc.b, rdc.r, rdc.g, rdc.b, rdc.r, rdc.g, rdc.b);
        }

    }

    public void GodEffect()
    {
        if (photonView.IsMine)
        {
            isGod = true;
            StartCoroutine(GodTimer());
        }
    }

    IEnumerator GodTimer()
    {
        yield return new WaitForSeconds(3f);
        isGod = false;
    }

    public void FlipEffect()
    {
        if (photonView.IsMine)
        {
            Debug.Log(playerModel.transform.localPosition + "asdfasdf");
            if (isFlip)
            {
                isFlip = false;

                playerModel.transform.localPosition = new Vector3(0, 0.1f, 0);
                playerModel.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                isFlip = true;
                playerModel.transform.localPosition = new Vector3(0, 0.258f, 0);
                playerModel.transform.rotation = Quaternion.Euler(0, 180, 180f);
            }
            
        }
    }



    public void BananaEffect()
    {
        if (photonView.IsMine)
        {
            Vector3 getVel = new Vector3(-0.6f, 0.7f, 0.0f) * speed;
            rigidbody.velocity = getVel;
        }
    }
    public void BottleEffect()
    {
        if (photonView.IsMine && !isAlchohol)
        {
            isAlchohol = !isAlchohol;
            StartCoroutine(BottleTimer());
        }
    }

    IEnumerator BottleTimer()
    {
        yield return new WaitForSeconds(5f);
        isAlchohol = false;
    }



    public void OctoEffect()
    {
        if (photonView.IsMine)
        {
            GameObject octoItem = hitBox.GetComponent<HitBoxManager>().octoItem;
            List<Sprite> octoImg = octoItem.GetComponent<ItemImgScript>().thisImg;
            StartCoroutine(OctoTimer(octoItem, octoImg));
        }
    }

    IEnumerator OctoTimer(GameObject octoItem, List<Sprite> octoImg)
    {
        int count = 0;
        octoItem.GetComponent<Image>().sprite = octoImg[count++];
        octoItem.SetActive(true);
        while (count < 3)
        {
            yield return new WaitForSeconds(0.5f);
            octoItem.GetComponent<Image>().sprite = octoImg[count++];
        }
        yield return new WaitForSeconds(3.5f);
        octoItem.SetActive(false);
    }




}
