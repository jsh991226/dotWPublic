using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;

public class BackEndGameDataInc : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        Param updateParam = new Param();
        updateParam.AddCalculation("testInt01", GameInfoOperator.addition, 1);              //increase
        //updateParam.AddCalculation("testInt", GameInfoOperator.subtraction, 1);         //decrease


        Where where = new Where();
        Backend.GameData.UpdateWithCalculation("testTable", where, updateParam);
    }
}
