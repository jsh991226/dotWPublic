using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger1 : MonoBehaviour
{
    public bool inTrigger = false;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            inTrigger = true;
        }
    }

}
