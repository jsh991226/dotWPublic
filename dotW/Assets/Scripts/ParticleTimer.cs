using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTimer : MonoBehaviour
{
    private float nowTimer;
    void Start()
    {
        nowTimer = 0;
    }
    private void FixedUpdate()
    {
        nowTimer += Time.fixedDeltaTime;
        if (nowTimer > 0.5f)
        {
            Destroy(gameObject);
        }
    }

}
