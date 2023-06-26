using UnityEngine;
using UnityEngine.UI;
using BackEnd;
using System;
using System.Collections.Generic;

public class BackEndGameInfo : MonoBehaviour
{

    public static void updateUserData(string tableName, string column, string updatestr) //string type
    {
        Param updateParam = new Param();
        updateParam.Add(column, updatestr); 
        Where where = new Where();
        Backend.GameData.Update(tableName, where, updateParam);
    }
    public static void updateUserData(string tableName, string column, int updateint) //int type
    {
        Param updateParam = new Param();
        updateParam.Add(column, updateint);
        Where where = new Where();
        Backend.GameData.Update(tableName, where, updateParam);
    }
    public static void addUserData(string tableName, string[] column, int increaseNum) //다중컬럼
    {
        Param updateParam = new Param();
        for ( int i = 0; i < column.Length; i++) updateParam.AddCalculation(column[i], GameInfoOperator.addition, increaseNum);              //increase
        //updateParam.AddCalculation("testInt", GameInfoOperator.subtraction, 1);         //decrease
        Where where = new Where();
        Backend.GameData.UpdateWithCalculation(tableName, where, updateParam);
    }

    public static void addUserData(string tableName, string column, int increaseNum) //단일컬럼
    {
        Param updateParam = new Param();
        updateParam.AddCalculation(column, GameInfoOperator.addition, increaseNum); 
        Where where = new Where();
        Backend.GameData.UpdateWithCalculation(tableName, where, updateParam);
    }


    public static List<string> GetData(string tableName, string[] column) //다중컬럼
    {
        BackendReturnObject BRO = Backend.GameData.GetMyData(tableName, new Where());
        List<string> returnTemp = new List<string>();
        if (BRO.IsSuccess())
        {
            for (int j = 0; j < column.Length; j++) for (int i = 0; i < BRO.Rows().Count; ++i) returnTemp.Add(BRO.Rows()[i][column[j]][0].ToString());
            return returnTemp;
        }
        else
        {
            Debug.Log("GetDataParam2 Error");
            return null;
        }

    }

    public static List<string> GetData(string tableName ,List<string> column) //다중컬럼
    {
        BackendReturnObject BRO = Backend.GameData.GetMyData(tableName, new Where());
        List<string> returnTemp = new List<string>();
        if (BRO.IsSuccess())
        {
            Debug.Log(BRO);
            for (int j = 0; j < column.Count; j++)
                for (int i = 0; i < BRO.Rows().Count; ++i)
                    returnTemp.Add(BRO.Rows()[i][column[j]][0].ToString());
            return returnTemp;
        }
        else
        {
            Debug.Log("GetDataParam3 Error");
            return null;
        }
       
    }
    public static string GetData(string tableName, string column) //단일컬럼
    {
        BackendReturnObject BRO = Backend.GameData.GetMyData(tableName, new Where());
        string returnTemp;
        if (BRO.IsSuccess())
        {
            returnTemp = BRO.Rows()[0][column][0].ToString();
            return returnTemp;
        }
        else
        {
            Debug.Log("GetDataParam2 Error");
            return null;
        }

    }
}
