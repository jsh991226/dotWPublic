using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerTuto : MonoBehaviour
{
    bool isRespawning = false;
    public List<Sprite> respawnImg;
    public GameObject ply;

    //public GameObject playerPrefab;

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
        if (reCount == 30) ply.transform.position = new Vector3(-1.264f, 4.08f, -0.72f);
        respawnImgCom.enabled = false;
        isRespawning = false;
    }


    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    public void gameQuit()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isRespawning)
        {
            isRespawning = true;
            StartCoroutine(reSpawnKey());
        }

        
    }









}
