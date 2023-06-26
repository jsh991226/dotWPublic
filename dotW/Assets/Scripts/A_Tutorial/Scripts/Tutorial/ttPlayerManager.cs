
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class ttPlayerManager : MonoBehaviour
{

    public int isSpace = 0;
    public int isPush = 0;
    public float speed = 3.0f;
    private Transform tr;
    public bool isJump;
    public Rigidbody rigidbody;
    //클론이 통신을 받는 변수 설정
    private Vector3 currPos;
    private Quaternion currRot;
    private Quaternion currModelRot;
    public Animator animator; // Animator 속성 변수 생성
    public GameObject hitBox;
    public GameObject playerModel;
    public GameObject myCamera;
    public GameObject TargetStm;
    public GameObject TargetBody;
    public GameObject Targetcheek;
    public Material mettemp;




    void Start()
    {
        tr = GetComponent<Transform>();
        isJump = false;
        Camera.main.GetComponent<SmoothFollowTuto>().target = tr.Find("CamPivot").transform;


    }



    public void goJump(float jumpLv, string key) {
        if (isJump == false)
        {
            if (key == "left")
            {

                isJump = true;
                Vector3 getVel = new Vector3(-0.6f * (jumpLv / 100), 0.7f*(jumpLv/100), 0.0f) * speed;
                playerModel.transform.rotation = Quaternion.Euler(0, 190f, 0);
                rigidbody.velocity = getVel;
                isPush++;
            }
            if (key == "right")
            {
                isJump = true;
                Vector3 getVel = new Vector3(0.6f * (jumpLv / 100), 0.7f * (jumpLv / 100), 0.0f) * speed;
                playerModel.transform.rotation = Quaternion.Euler(0, 170f, 0);
                rigidbody.velocity = getVel;
                isPush++;
            }
            if (key == "space")
            {
                isJump = true;
                Vector3 getVel = new Vector3(0.0f, 0.7f * (jumpLv / 100), 0.0f) * speed;
                rigidbody.velocity = getVel;
                isSpace++;
            }
            if (Camera.main.GetComponent<SmoothFollowTuto>().isjump == false && Camera.main.GetComponent<SmoothFollowTuto>().isdown == false) Camera.main.GetComponent<SmoothFollowTuto>().corJumpUp();

        }



    }




}
