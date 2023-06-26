using System.Collections;
using System.Collections.Generic;
using UnityEngine;







public class AnimManager : MonoBehaviour
{
    Animation anim;
    public AnimationClip jumpAnim;
    public AnimationClip downAnim;
    public AnimationClip jumpingAnim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            anim.clip = jumpAnim;
            anim.Play();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.clip = downAnim;
            anim.Play();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.clip = jumpingAnim;
            anim.Play();
        }
    }
}