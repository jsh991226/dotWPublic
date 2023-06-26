using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RunnerBarManager : MonoBehaviour//, IPunObservable
{
    public List<GameObject> barGroup = new List<GameObject>();
    public GameObject myCharIcon;
    public GameObject anotherCharGroup;
    public GameObject anotherCharPrefab;
    public GameObject myPlayer;
    public GameObject myAnotherIcon;
    private int barCount = 0;
    private float width = 260;
    private float sideWidth = 240;
    private List<float> stagePx = new List<float>();
    private Vector3 nowPos = new Vector3(83f, 1020f, 0f);
    private IEnumerator moveCor;

 

 



    public void BarListStart()
    {
        for ( int i = 0; i < barGroup.Count; i++)
        {
            if (i == 0 || i == (barGroup.Count - 1)) stagePx.Add(sideWidth / barGroup[i].transform.childCount);
            else stagePx.Add(width / barGroup[i].transform.childCount);
            for (int j = 0; j < barGroup[i].transform.childCount; j++)
            {
                barGroup[i].transform.GetChild(j).GetComponent<RunnerBar>().myBoxNum = ++barCount;
                barGroup[i].transform.GetChild(j).GetComponent<RunnerBar>().myStageNum = i;
                nowPos.x += stagePx[i];
                barGroup[i].transform.GetChild(j).GetComponent<RunnerBar>().myPos = nowPos;
                barGroup[i].transform.GetChild(j).GetComponent<RunnerBar>().runnerGroup = gameObject;
            }
        }

    }
    IEnumerator MoveCor(Vector3 movePosition)
    {
        while (Vector3.Distance(myCharIcon.transform.position, movePosition) > 0.05f)
        {
            myCharIcon.transform.position = Vector3.Lerp(myCharIcon.transform.position, movePosition, 0.05f);
            myAnotherIcon.transform.position = Vector3.Lerp(myAnotherIcon.transform.position, movePosition, 0.05f);
            yield return null;
        }

    }

    public void MyCharMove(Vector3 movePosition)
    {
        if (moveCor != null) StopCoroutine(moveCor);
        moveCor = MoveCor(movePosition);
        StartCoroutine(moveCor);
        
        
    }


}
