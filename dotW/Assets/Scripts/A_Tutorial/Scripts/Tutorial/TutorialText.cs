using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class TutorialText : MonoBehaviourPunCallbacks
{
    public float time1 = 0f;
    public GameObject textObj; //text
    public GameObject hitbox;
    public GameObject player;
    public int nowIndex = 5;
    public GameObject trigger1;
    public GameObject trigger2;
    public GameObject trigger3;
    public GameObject resTrigger;
    public GameObject waterTrigger;
    public GameObject itemTrigger;
    public List<Sprite> respawnImg;
    public GameObject itemBox;
    public GameObject inven;
    bool isRespawning = false;
    List<string> textMsg = new List<string>();

    private void Awake()
    {
        Debug.Log("어웨이크다 이 씨발새끼들아");
    }

    void Start()
    {
        player.GetComponent<ttPlayerManager>().isJump = true;
        textMsg.Add("Dot'W에 오신것을 환영합니다.");
        textMsg.Add("보다 더 멋진 개구리가 되기 위해 춤 연습을 해볼까 해요.");
        textMsg.Add("제자리 점프는 스페이스바로 가능합니다. 점프는 박자에 맞춰서 해야지만 가능합니다.");
        textMsg.Add("가운데 오는 노트를 보면서 점프해보세요.");
        textMsg.Add("잘했어요!");//5
        textMsg.Add("혹시 눈치 채셨나요?");
        textMsg.Add("이 게임의 점프 성공 판정에는 퍼펙트, 그레이트, 굿 총 3가지의 판정이 있어요.");
        textMsg.Add("박자에 가장 잘 맞을 수록 퍼펙트, 박자에서 멀어질 수록 그레이트, 굿 순으로 판정이 됩니다.");
        textMsg.Add("오른쪽이나 왼쪽 방향키를 박자에 맞게 눌러 점프해보세요.");
        textMsg.Add("노트 판정이 정확할수록 점프 거리, 점프 높이도 높아진답니다.");//10
        textMsg.Add("점프를 해서 오른쪽에 있는 계단을 넘어가봅시다!");//11
        textMsg.Add("잘하고 있어요!");//12
        textMsg.Add("어라? 앞에 구덩이가 있네요!");//13
        textMsg.Add("아랫쪽에 신기한게 있을지도 몰라요 아래로 떨어져봅시다");//14
        textMsg.Add("이런! 아래쪽에 아무것도 없고 앞으로 나아가지 못하는 상황이 되어버렸군요");//15
        textMsg.Add("괜찮아요 그럴때는 R키를 눌러서 처음으로 리스폰을 할 수 있어요.");//16
        textMsg.Add("R키를 꾹 눌러 리스폰을 해주세요.");//17
        textMsg.Add("잘하셨어요!! 빠른 진행을 위해 리스폰 지역을 조정했어요!");
        textMsg.Add("앞에 물이 있네요.");
        textMsg.Add("춤 추는데 물 속으로 들어가면 방해가 되겠죠?"); // 20
        textMsg.Add("물을 피해서 안전한 장소로 대피해보세요."); // 21
        textMsg.Add("잘했어요!!"); //22
        textMsg.Add("저기 무언가가 있네요. 가까이 가볼까요?"); //23
        textMsg.Add("아이템 박스가 있네요! 가까이 가서 먹어볼까요?"); //24
        textMsg.Add("아래 아이템 창에 아이템이 생겼네요!"); //25
        textMsg.Add("어떤 아이템인지는 해당 아이템 위에 마우스를 올리면 설명을 볼 수 있어요."); //26
        textMsg.Add("아이템 사용은 우물 밖에서 해보세요!."); //27
        textMsg.Add("이제 춤 출 준비가 완료되었네요."); //28
        textMsg.Add("지금부터 우물 밖에서 실력을 뽐내러가볼까요?"); //29

        PlayText();
    }
    public void ShowNextMsg(float time)
    {
        textObj.GetComponent<Text>().enabled = true;
        textObj.GetComponent<Text>().text = textMsg[nowIndex++];
        StartCoroutine(MsgReturn(time));
    }

    IEnumerator MsgReturn(float time)
    {
        yield return new WaitForSeconds(3.0f);
        textObj.GetComponent<Text>().enabled = false;
        PlayText();
    }
    IEnumerator GoIngame(float time)
    {
        yield return new WaitForSeconds(2.0f);
        string roomNameSample = "gameRoom_1207";
        PhotonNetwork.JoinOrCreateRoom(roomNameSample, new RoomOptions { MaxPlayers = 10 }, null);
    }

    public override void OnJoinedRoom()//방에 들어갔을때 작동
    {
        Debug.Log("튜툐리얼 to 인게임");
        PhotonNetwork.LoadLevel("GameScene");
    }
    public void PlayText()
    {
        if (nowIndex == 0)//nowIndex값이 보이고 있다면
        {
            ShowNextMsg(3f);
        }
        else if (nowIndex == 1)
        {
            ShowNextMsg(3f);
        }
        else if (nowIndex == 2)
        {
            ShowNextMsg(3f);
            hitbox.SetActive(true);
        }
        else if (nowIndex == 3)
        {
            ShowNextMsg(3f);
        }
        else if (nowIndex == 4)
        {
            player.GetComponent<ttPlayerManager>().isJump = false;
        }
        else if (nowIndex == 5)
        {
            player.GetComponent<ttPlayerManager>().isJump = true;
            ShowNextMsg(3f);
        }
        else if (nowIndex == 6)
        {
            ShowNextMsg(3f);
        }
        else if (nowIndex == 7)
        {
            ShowNextMsg(3f);
        }
        else if (nowIndex == 8)
        {
            ShowNextMsg(3f);
            hitbox.SetActive(true);
            player.GetComponent<ttPlayerManager>().isJump = false;
        }
        else if (nowIndex == 9)
        {
            
        }
        else if (nowIndex == 10)
        {
            ShowNextMsg(3f);
            hitbox.SetActive(true);
            player.GetComponent<ttPlayerManager>().isJump = false;
        }
        else if (nowIndex == 11)
        {
            
        }
        else if (nowIndex == 12)
        {
            ShowNextMsg(3f);
        }
        else if (nowIndex == 13)
        {
            ShowNextMsg(3f);
            hitbox.SetActive(true);
            player.GetComponent<ttPlayerManager>().isJump = false;
        }
        else if (nowIndex == 14)
        {

        }
        else if (nowIndex == 15)
        {
            ShowNextMsg(3f);
        }
        else if (nowIndex == 16)
        {
            ShowNextMsg(3f);
        }
        else if (nowIndex == 17)
        {

        }
        else if (nowIndex == 18) // 리스폰 하고 다시 시작
        {
            ShowNextMsg(3f);
        }
        else if (nowIndex == 19)
        {
            ShowNextMsg(3f);
        }
        else if (nowIndex == 20) 
        {
            ShowNextMsg(3f);
        }
        else if (nowIndex == 21) // 물을 피해서 어쩌구 저쩌구
        {
            hitbox.SetActive(true);
            player.GetComponent<ttPlayerManager>().isJump = false;
        }
        else if (nowIndex == 22) // 잘했어요
        {
            ShowNextMsg(3f);
        }
        else if (nowIndex == 23)
        {
            hitbox.SetActive(true);
            player.GetComponent<ttPlayerManager>().isJump = false;
        }
        else if (nowIndex == 24)
        {
  
        }
        else if (nowIndex == 25)
        {
            ShowNextMsg(3f);
        }
        else if (nowIndex == 26)
        {
            ShowNextMsg(3f);
        }
        else if (nowIndex == 27)
        {
            ShowNextMsg(3f);
        }
        else if (nowIndex == 28)
        {
            ShowNextMsg(3f);
        }
        else if (nowIndex == 29)
        {
            StartCoroutine(GoIngame(3f));
        }

    }

    [System.Obsolete]
    private void Update()
    {
        if (nowIndex == 4 && player.GetComponent<ttPlayerManager>().isSpace >= 5)
        {
            time1 += Time.deltaTime;
            if (time1 >= 0.95)
            {
                hitbox.SetActive(false);
                time1 = 0;
                ShowNextMsg(3f + time1);
            }
        }
        if (nowIndex == 9 && player.GetComponent<ttPlayerManager>().isPush >= 3)
        {
            time1 += Time.deltaTime;
            if (time1 >= 1.05)
            {
                hitbox.SetActive(false);
                player.GetComponent<ttPlayerManager>().isJump = true;
                ShowNextMsg(3f + time1);
                time1 = 0;
            }
        }
        if (nowIndex == 11 && trigger1.GetComponent<trigger1>().inTrigger == true)
        {
            time1 += Time.deltaTime;
            if (time1 >= 1.05)
            {
                hitbox.SetActive(false);
                player.GetComponent<ttPlayerManager>().isJump = true;
                ShowNextMsg(3f + time1);
                time1 = 0;
            }
        }
        if (nowIndex == 14 && trigger2.GetComponent<trigger1>().inTrigger == true)
        {
            time1 += Time.deltaTime;
            if (time1 >= 1.05)
            {
                hitbox.SetActive(false);
                player.GetComponent<ttPlayerManager>().isJump = true;
                ShowNextMsg(3f + time1);
                time1 = 0;
            }
        }
        if (nowIndex == 17 && resTrigger.GetComponent<trigger1>().inTrigger == true) //&&R키로 리스폰을 했다면
        {
            time1 += Time.deltaTime;
            if (time1 >= 1.05)
            {
                hitbox.SetActive(false);
                player.GetComponent<ttPlayerManager>().isJump = true;
                ShowNextMsg(3f + time1);
                time1 = 0;
            }
        }
        if (nowIndex == 21 && trigger3.GetComponent<trigger1>().inTrigger == true)
        {
            time1 += Time.deltaTime;
            if (time1 >= 1.05)
            {
                hitbox.SetActive(false);
                player.GetComponent<ttPlayerManager>().isJump = true;
                ShowNextMsg(3f + time1);
                time1 = 0;
            }
        }
        if (nowIndex == 21 && waterTrigger.GetComponent<trigger1>().inTrigger == true)
        {
                waterTrigger.GetComponent<trigger1>().inTrigger = false;
                player.transform.position = new Vector3(6.7f, 4.2f, -0.1f);
        }
        if (nowIndex == 23 && itemTrigger.GetComponent<trigger1>().inTrigger == true)
        {
            ShowNextMsg(3f);
            inven.SetActive(true);
        }

        if (nowIndex == 24 && itemBox.active == false)
        {
            Debug.Log("242424242424242424");
            ShowNextMsg(3f);
        }
        if (nowIndex>=17&&Input.GetKeyDown(KeyCode.R) && !isRespawning && trigger2.GetComponent<trigger1>().inTrigger == true)
        {
            isRespawning = true;
            StartCoroutine(reSpawnKey());
        }

    }
    IEnumerator reSpawnKey()
    {
        int reCount = 0;
        int imgCnt = 0;
        Image respawnImgCom = GameObject.Find("RespawnImg").GetComponent<Image>();
        respawnImgCom.sprite = respawnImg[imgCnt];
        respawnImgCom.enabled = true;
        while (reCount < 30)
        {
            reCount++;
            yield return new WaitForSeconds(0.05f);
            if ((reCount) % 5 == 0 && imgCnt < respawnImg.Count - 1)
            {
                respawnImgCom.sprite = respawnImg[++imgCnt];
            }
            if (!Input.GetKey(KeyCode.R)) break;
        }
        if (reCount == 30) player.transform.position = new Vector3(6.7f, 4.2f, -0.1f);
        respawnImgCom.enabled = false;
        isRespawning = false;
    }
}