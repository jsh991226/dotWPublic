using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using BackEnd;
using System;

public class BackEndAuthentication : MonoBehaviour
{
    public InputField idInput;
    public InputField pwInput;
    public InputField nickInput;
    private string tableName = "UserData";
    public GameObject nicknameGroup;
    public GameObject loginTabMenu;
    public GameObject msgBoxManager;
    public MsgBox msgManager;

    [SerializeField]
    private AudioClip loginFail;
    [SerializeField]
    private AudioClip loginSucc;
    [SerializeField]
    private AudioSource audioComp;

    private void Awake()
    {
        msgManager = msgBoxManager.GetComponent<MsgBox>();
    }
    public void OnClickSignUp()
    {
        //first length check code
        if (idInput.text.Length > 20 || idInput.text.Length < 4)
        {
            StatusMsg("1001");
            return;
        }
        if (pwInput.text.Length > 20 || pwInput.text.Length < 8)
        {
            StatusMsg("1002");
            return;
        }
        BackendReturnObject BRO = Backend.BMember.CustomSignUp(idInput.text, pwInput.text, "etc");
        Param param = new Param();
        param.Add("userID", idInput.text);
        param.Add("test", "ganadaramabasa");
        BackendReturnObject BROInsertTest = Backend.GameData.Insert(tableName, param);
        
        try
        {
            if (BRO.IsSuccess() && BROInsertTest.IsSuccess())
            {
                msgManager.viewMsg("회원가입 성공!", 1.3f);
                audioComp.clip = loginSucc;
                audioComp.Play();
                pwInput.text = null;
                loginTabMenu.GetComponent<MenuTab>().onClickShowMe();
                loginTabMenu.GetComponent<CheckBtnManager>().onClick();
            }
            else
            {
                audioComp.clip = loginFail;
                audioComp.Play();
                StatusMsg(BRO.GetStatusCode());
            }
        } catch(Exception e)
        {
            audioComp.clip = loginFail;
            audioComp.Play();
            StatusMsg("409");
        }
    }
    public void StatusMsg(string code)
    {
        string msg = null;
        switch(code)
        {
            case "1001":
                msg = "아이디는 4~20글자 사이입니다."; break;
            case "1002":
                msg = "비밀번호는 8~20글자 사이입니다."; break;
            case "400":
                msg = "빈칸이 존재 합니다."; break;
            case "401":
                msg = "계정 정보가 잘못 되었습니다.";break;
            case "403":
                msg = "차단 당한 계정입니다."; break;
            case "409":
                msg = "이미 존재하는 계정 입니다."; break;
            default:
                msg = "알수없는 오류 [ code : " + code + " ]"; break;
        }
        msgManager.viewMsg(msg, 1.3f, true);
    }


    public void OnClickLogin()
    {
        BackendReturnObject BRO = Backend.BMember.CustomLogin(idInput.text, pwInput.text);

        if (BRO.IsSuccess())
        {
            //string[] test = {"userID", "test"};
            string getNick = BackEndGameInfo.GetData(tableName, "nickName");
            //for (int i = 0; i < returnTemp.Count; i++) Debug.Log(returnTemp[i]);
            msgManager.viewMsg("로그인 성공!", 1.3f);
            audioComp.clip = loginSucc;
            audioComp.Play();
            nicknameGroup.GetComponent<MenuTab>().onClickShowMe();
            if (getNick != "$") nickInput.text = getNick;
        }
        else
        {
            audioComp.clip = loginFail;
            audioComp.Play();
            StatusMsg(BRO.GetStatusCode());
        }
    }
    public static void backEndLogOut()
    {
        Backend.BMember.Logout();
    }

}
