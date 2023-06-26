using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverAchievement : MonoBehaviour
{

    public ObserverAchievement nextOb = null;
    public int code;

    public virtual void Notify(int eventCode)
    {

    }

}
