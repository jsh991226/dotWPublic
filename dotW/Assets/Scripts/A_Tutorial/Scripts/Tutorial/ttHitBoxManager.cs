using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ttHitBoxManager : MonoBehaviour
{
    public GameObject notes;
    public GameObject note;
    public float bpm;
    public float interval;
    public float nextTime;
    public bool gameing = false;
    public float noteMoveTime;
    private int maxNoteCnt = 5;
    List<GameObject> leftNoteList = new List<GameObject>();
    List<GameObject> rightNoteList = new List<GameObject>();
    public List<Texture> loadingSprite = new List<Texture>();
    public RawImage HitUI;
    public Texture defaultUI;
    public Texture pointUI;
    private bool isHit = false;
    public GameObject GameManager;
    private bool mPlay = false;
    private float playerTimeCheck = 0.0f;
    public GameObject loadEQ;
    public GameObject loadText;
    public GameObject HitText;
    public int loadCnt = 0;
    public int upCnt = 0;
    public Texture gamestartImg;
    public GameObject hitBorderobj;
    public bool possJump;
    public GameObject playerObj;

    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        interval = 60f / bpm;
    }

    //마지막 -> 중앙 거리 694픽셀 / 틱당 2픽셀 총 347픽셀
    private void newNote()
    {

        GameObject note_left = Instantiate(note, new Vector3(149.4f, 434.5f, 0), Quaternion.identity);
        note_left.transform.parent = notes.transform;
        GameObject note_right = Instantiate(note, new Vector3(1771.4f, 434.5f, 0), Quaternion.identity);
        note_right.transform.parent = notes.transform;
        if (mPlay == false)
        {
            Color color = note_left.GetComponent<RawImage>().color;
            color.a = 0.0f;
            note_left.GetComponent<RawImage>().color = color;
            note_right.GetComponent<RawImage>().color = color;
        }
        leftNoteList.Add(note_left);
        rightNoteList.Add(note_right);
    }
    public void setLoadImg()
    {
        loadEQ.GetComponent<RawImage>().texture = loadingSprite[loadCnt];
        upCnt++;
        if (upCnt > 3)
        {
            loadCnt++;
            upCnt = 0;
        }
        if (loadCnt > loadingSprite.Count - 1) loadCnt = 0;
    }
    IEnumerator hitImage()
    {
        hitBorderobj.GetComponent<RawImage>().enabled = true;
        Color color = hitBorderobj.GetComponent<RawImage>().color;
        color.a = 1.0f;
        hitBorderobj.GetComponent<RawImage>().color = color;
        while (color.a > 0)
        {
            color.a -= 0.2f;
            hitBorderobj.GetComponent<RawImage>().color = color;
            yield return new WaitForSeconds(0.006f);
        }
        hitBorderobj.GetComponent<RawImage>().enabled = false;
    }

    private void FixedUpdate()
    {

        if (gameing == false)
        {
            playerTimeCheck += Time.fixedDeltaTime;
            //GameManager.GetComponent<GameManager>().setJoinColor();
            nextTime = Time.time + interval;
            noteMoveTime = Time.time;
            gameing = true;
            //Camera.main.GetComponent<AudioSource>().Play();
            possJump = true;
            mPlay = true;
        } else
        {
            if (mPlay == false) setLoadImg();

            if (Time.time >= nextTime)
            {
                nextTime += interval;

                noteMoveTime += (interval / 382);
                if (leftNoteList.Count < maxNoteCnt)
                {
                    newNote();
                }

            }
            float jumplv = 0.0f;
            string keyvalue = "";
            int jumplvint = 0;
            if (Input.GetKey("left") || Input.GetKey("right") || Input.GetKey("space"))
            {
                if (possJump != true) return;
                if (Input.GetKey("left")) keyvalue = "left";
                if (Input.GetKey("right")) keyvalue = "right";
                if (Input.GetKey("space")) keyvalue = "space";
                GameObject obj = leftNoteList[0];
                GameObject objr = rightNoteList[0];
                if (obj.transform.position.x >= 843 && obj.transform.position.x < 890)
                {
                    jumplv = 60.0f;
                    isHit = true;
                    jumplvint = 1;

                }
                else if (obj.transform.position.x >= 890 && obj.transform.position.x < 935)
                {
                    jumplv = 80.0f;
                    isHit = true;
                    jumplvint = 2;

                }
                else if (obj.transform.position.x >= 935 && obj.transform.position.x <= 980)
                {
                    jumplv = 100.0f;
                    isHit = true;
                    jumplvint = 3;

                }
                if (isHit == true)
                {
                    HitText.GetComponent<HitText>().changeImage(jumplvint);
                    //StartCoroutine(hitImage());
                    obj.GetComponent<Notes>().noteHitAni(jumplvint);
                    leftNoteList.Remove(obj);
                    objr.GetComponent<Notes>().noteHitAni(jumplvint);
                    rightNoteList.Remove(objr);
                    
                    isHit = false;
                    playerObj.GetComponent<ttPlayerManager>().goJump(jumplv, keyvalue);
                }


            }
            if (Time.time >= noteMoveTime)
            {
                for (int i = 0; i < leftNoteList.Count; i++)
                {
                    GameObject noteObj = leftNoteList[i];
                    GameObject noteObjr = rightNoteList[i];
                    noteObj.transform.position += new Vector3(32 / maxNoteCnt, 0, 0);
                    noteObjr.transform.position += new Vector3(-32 / maxNoteCnt, 0, 0);

                    if (noteObj.transform.position.x > 756 && noteObj.GetComponent<Notes>().imGrown == false)
                    {
                        noteObj.GetComponent<Notes>().growUp();
                        noteObjr.GetComponent<Notes>().growUp();
                    }

                    if (noteObj.transform.position.x > 960)
                    {
                        Destroy(noteObj);
                        Destroy(noteObjr);
                        leftNoteList.RemoveAt(i);
                        rightNoteList.RemoveAt(i);
                    }
                }
                noteMoveTime += (interval / 382);
            }


        }
 

    }
}
