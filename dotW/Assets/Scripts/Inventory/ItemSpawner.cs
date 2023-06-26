using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ItemSpawner : MonoBehaviourPunCallbacks
{
    public GameObject rangeObject;
    public GameObject itemBox;
    BoxCollider rangeCollider;
    public GameObject spawnItem;
    public int respawnTime = 5;
    bool goCoroutine = false;



    private void Awake()
    {
        rangeObject = gameObject;
        rangeCollider = rangeObject.GetComponent<BoxCollider>();
    }
    public void Start()
    {
        if (spawnItem == null)
        {
            spawnItem = Instantiate(itemBox, Return_RandomPosition(), Quaternion.identity);
        }
    }


    [System.Obsolete]
    void Update()
    {
        if (spawnItem.active == false && goCoroutine == false)
        {
            StartCoroutine(respawnItem());
        }
        
    }
    IEnumerator respawnItem()
    {
        goCoroutine = true;
        yield return new WaitForSeconds(respawnTime);
        spawnItem.transform.position = Return_RandomPosition();
        spawnItem.SetActive(true);
        Debug.Log("아이템 재생성됨");
        goCoroutine = false;
    }        


    private Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeObject.transform.position;
        float range_X = rangeCollider.bounds.size.x;
        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        Vector3 RandomPostion = new Vector3(range_X, 0, -0.72f);
        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }



}
