using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    public InputField NickNameInput;
    private string roomNameSample;
    public Camera mainCamera;
    public Camera loadingCamera;
    public GameObject loginCanvas;
    public bool nowLoading = false;
    public GameObject msgBoxManager;
    public MsgBox msgManager;
    public Texture2D cursorImg;


    private void Awake()
    {

        PhotonNetwork.AutomaticallySyncScene = true;
        Screen.SetResolution(1920, 1080, true);
        msgManager = msgBoxManager.GetComponent<MsgBox>();

    }
    public void gameQuit()
    {
        Application.Quit();
    }

    private void Start()
    {
        Debug.Log("Connect to Master");
        Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);
        PhotonNetwork.ConnectUsingSettings();//포톤에 연결
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connect to Master");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Join to Lobby");
        loginCanvas.SetActive(true);
    }
    public void CreateRoom()//방만들기
    {
        if (NickNameInput.text.Length > 20 || NickNameInput.text.Length < 2)
        {
            msgManager.viewMsg("닉네임은 2~20글자 사이입니다.", 1.3f, true);
            return;
        }
        Debug.Log("클릭은 됩니다");
        loginCanvas.SetActive(false);
        roomNameSample = "gameRoom_1207";
        string nickName = NickNameInput.text;
        PhotonNetwork.LocalPlayer.NickName = nickName;
        BackEndGameInfo.updateUserData("UserData", "nickName", nickName);
        string tutoCheck = BackEndGameInfo.GetData("UserData", "tutoCheck");
        if (tutoCheck.Equals("$"))
        {
            Debug.Log("튜툐리얼 진입");
            BackEndGameInfo.updateUserData("UserData", "tutoCheck", "Check");
            SceneManager.LoadScene("Tutorial_scene");
        }
        else
        {
            PhotonNetwork.JoinOrCreateRoom(roomNameSample, new RoomOptions { MaxPlayers = 10 }, null);
        }


    }
    public override void OnJoinedRoom()//방에 들어갔을때 작동
    {
        Debug.Log("방 생성 진짜  됩니다");
        PhotonNetwork.LoadLevel("GameScene");
    }



}
