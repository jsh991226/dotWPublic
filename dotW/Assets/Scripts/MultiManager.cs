using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MultiManager : MonoBehaviourPunCallbacks
{
    public Text ServerText;
    public Text SceneText;
    public Text NickNameText;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Load New Scene");
        ServerText.text = "Server : " + PhotonNetwork.CurrentRoom.Name;
        SceneText.text = "Scene : " + SceneManager.GetActiveScene().name;
        NickNameText.text = "NickName : " + PhotonNetwork.LocalPlayer.NickName;

    }


}
