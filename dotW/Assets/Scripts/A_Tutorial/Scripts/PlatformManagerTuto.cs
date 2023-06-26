using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class PlatformManagerTuto : MonoBehaviour
{
    // Start is called before the first frame update
    //public Animator animator; // Animator 속성 변수 생성
    public GameObject hbManager;


    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "deathZone" && other.transform.tag=="Player")
        {
            other.transform.position = new Vector3(12.52f, 5f, -0.35f);
            Debug.Log("사망");
        }


        if (other.tag == "playerLeg")
        {
            if (Camera.main.GetComponent<SmoothFollowTuto>().isdown == false && Camera.main.GetComponent<SmoothFollowTuto>().isjump == true) Camera.main.GetComponent<SmoothFollowTuto>().corJumpDown();

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {

                collision.transform.GetComponent<ttPlayerManager>().isJump = false;


        }

    }

    

}
