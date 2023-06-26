using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;

public class BackEndManager : MonoBehaviour
{
    void Start()
    {
        var bro = Backend.Initialize(true);
        if (bro.IsSuccess())Debug.Log("??? ??");
        else Debug.LogError("??? ??!");
    }

}
