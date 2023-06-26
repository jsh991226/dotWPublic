using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; //선언
using Photon.Realtime; //선언
using UnityEngine.UI;
using System.Threading;

public class GameManager : MonoBehaviourPunCallbacks
{
    //public GameObject playerPrefab;
    public GameObject pObj;
    public GameObject ply ;
    public GameObject HitBoxPrefab;
    public GameObject HitBox;
    public GameObject MenuTab;
    public GameObject statusGUI;
    public GameObject settingGUI;
    public Text textID;
    public Text textNick;
    public Text textJump;
    public string userColorCode;
    bool isRespawning = false;
    public List<Sprite> respawnImg;
    public GameObject achiDefault;
    public GameObject creditObj;
    public GameObject myAnotherIcon;
    public List<GameObject> runnerBar = new List<GameObject>();
    

    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    public void gameQuit()
    {
        Application.Quit();
    }
    public void returnLobby()
    {
        Debug.Log("Return test");

        BackEndAuthentication.backEndLogOut();
        PhotonNetwork.LeaveRoom();

    }
    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("Launcher");
    }


    void LoadArena()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
        }
        Debug.LogFormat("PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
        //PhotonNetwork.LoadLevel("GameScene");
    }
    #region Photon Callbacks
    public override void OnPlayerEnteredRoom(Player other)
    {
        Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName); // not seen if you're the player connecting


        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom


            LoadArena();
        }
    }




    public override void OnPlayerLeftRoom(Player other)
    {
        Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName); // seen when other disconnects


        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom


            LoadArena();
        }
    }


    #endregion


    void Start()
    {
        ply = PhotonNetwork.Instantiate("Player", new Vector3(-1.264f, 2.08f, -0.72f), Quaternion.identity, 0);
        HitBox = Instantiate(HitBoxPrefab, new Vector3(0, -560.0f, 0), Quaternion.identity);
        GameObject runnerM = HitBox.GetComponent<HitBoxManager>().runnerManager;
        ply.transform.parent = pObj.transform;
        ply.GetComponent<playerManager>().hitBox = HitBox;
        ply.GetComponent<playerManager>().achiControler = achiDefault;
        ply.GetComponent<playerManager>().notifyObj = HitBox.GetComponent<HitBoxManager>().userNotify;
        runnerM.GetComponent<RunnerBarManager>().barGroup = runnerBar;
        runnerM.GetComponent<RunnerBarManager>().myPlayer = ply;
        runnerM.GetComponent<RunnerBarManager>().BarListStart();
        ply.GetComponent<playerManager>().runnerManager = runnerM;
        ply.GetComponent<playerManager>().SetMyIcon();
        string[] queryTemp = { "userID", "nickName", "userJump", "customColor"};
        List<string> queryResult = BackEndGameInfo.GetData("UserData", queryTemp);
        textID.text = queryResult[0];
        textNick.text = queryResult[1];
        textJump.text = queryResult[2];
        userColorCode = queryResult[3];
        ply.GetComponent<playerManager>().joinCustomColor(userColorCode);
        achiDefault.GetComponent<AchievementManager>().PlayerJoinCheck();


    }

    IEnumerator reSpawnKey()
    {
        int reCount = 0;
        int imgCnt = 0;
        Image respawnImgCom = GameObject.Find("RespawnImg").GetComponent<Image>();
        respawnImgCom.sprite = respawnImg[imgCnt];
        respawnImgCom.enabled = true;
        while (reCount<30)
        {
            reCount++;
            yield return new WaitForSeconds(0.05f);
            if ((reCount)% 5 == 0 && imgCnt < respawnImg.Count-1)
            {
                respawnImgCom.sprite = respawnImg[++imgCnt];
            }
            if (!Input.GetKey(KeyCode.R)) break;
        }
        if (reCount == 30) ply.transform.position = new Vector3(-1.264f, 4.08f, -0.72f);
        respawnImgCom.enabled = false;
        isRespawning = false;
    }

    // Update is called once per frame
    public void ContinueGame()
    {
        MenuTab.SetActive(false);
        statusGUI.SetActive(false);
        settingGUI.SetActive(false);
        creditObj.SetActive(false);
        ply.transform.position = new Vector3(-1.264f, 4.08f, -0.72f);
        HitBox.SetActive(true);
        HitBox.GetComponent<HitBoxManager>().resetBit();
    }


    [System.Obsolete]
    void Update()
    {
        if (HitBox.GetComponent<HitBoxManager>().possJump != true) return;
        if (Input.GetKeyDown(KeyCode.Escape) && HitBox.active == true && MenuTab.active == false)
        {
            Camera.main.GetComponent<AudioSource>().Stop();
            HitBox.SetActive(false);
            MenuTab.SetActive(true);
            settingGUI.SetActive(true);
            statusGUI.SetActive(false);
            ply.GetComponent<playerManager>().playerSettingIconToggle(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && HitBox.active == false && MenuTab.active == true)
        {
            HitBox.SetActive(true);
            HitBox.GetComponent<HitBoxManager>().resetBit();
            MenuTab.SetActive(false);
            ply.GetComponent<playerManager>().playerSettingIconToggle(false);
        }

        if (Input.GetKeyDown(KeyCode.Tab) && HitBox.active == true && MenuTab.active == false)
        {
            Camera.main.GetComponent<AudioSource>().Stop();
            HitBox.SetActive(false);
            MenuTab.SetActive(true);
            settingGUI.SetActive(false);
            statusGUI.SetActive(true);
            statusGUI.GetComponent<StatusGuide>().applyMsg.SetActive(false);
            textJump.text = BackEndGameInfo.GetData("UserData", "userJump");
            ply.GetComponent<playerManager>().playerSettingIconToggle(true);
            achiDefault.GetComponent<AchievementManager>().ViewPage();
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && HitBox.active == false && MenuTab.active == true)
        {
            HitBox.SetActive(true);
            HitBox.GetComponent<HitBoxManager>().resetBit();
            MenuTab.SetActive(false);
            ply.GetComponent<playerManager>().playerSettingIconToggle(false);
        }

        if (Input.GetKeyDown(KeyCode.R) && !isRespawning) {
            isRespawning = true;
            StartCoroutine(reSpawnKey());
        }


    }


}
