using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotifyManager : MonoBehaviour
{
    public GameObject notifyObj;
    public GameObject notifyText;
    private IEnumerator nowNoty;

    public void setNotify(string msg)
    {
        setNotifyText(msg);
        viewNotify();
        if (nowNoty != null) StopCoroutine(nowNoty);
        nowNoty = slideNotify();
        StartCoroutine(nowNoty);
    }


    IEnumerator slideNotify()
    {
        int count = 0;
        while (count < 39)
        {
            notifyObj.transform.position = new Vector3(960, 619 - ((++count)*2), 0);
            yield return new WaitForSeconds(0.00005f);
        }
        yield return new WaitForSeconds(1f);
        while (count > 0)
        {
            notifyObj.transform.position = new Vector3(960, 619 - ((--count)*2), 0);
            yield return new WaitForSeconds(0.00005f);
        }

    }


    public void setNotifyText(string msg) {
        notifyText.GetComponent<Text>().text = msg;
    }

    public void viewNotify()
    {
        notifyObj.transform.position = new Vector3(960, 619, 0);
    }

    
}
