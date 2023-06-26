using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ItemBox : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public GameObject boxModel;
    public float nowHeight;
    public bool upFlag = false;
    public AudioClip itemBoxSound;

    public List<ItemManager> itemSample = new List<ItemManager>();

    void Start()
    {
        nowHeight = boxModel.GetComponent<CapsuleCollider>().height;
        itemSample.Add(new Item1());
        itemSample.Add(new Item2());
        itemSample.Add(new Item3());
        itemSample.Add(new Item4());
        itemSample.Add(new Item7());
        itemSample.Add(new Item8());
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 70.0f * Time.deltaTime, 0));
        if (upFlag == false)
        {
            if (boxModel.GetComponent<CapsuleCollider>().height <= 0.6f) boxModel.GetComponent<CapsuleCollider>().height -= 0.005f;
            else boxModel.GetComponent<CapsuleCollider>().height -= 0.01f;
            if ( boxModel.GetComponent<CapsuleCollider>().height <= 0.5) upFlag = true;
        }else if (upFlag == true)
        {
            if (boxModel.GetComponent<CapsuleCollider>().height >= 0.80f) boxModel.GetComponent<CapsuleCollider>().height += 0.005f;
            else boxModel.GetComponent<CapsuleCollider>().height += 0.01f;
            if (boxModel.GetComponent<CapsuleCollider>().height > 0.88) upFlag = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<PhotonView>().IsMine)
            {

                int getItem = Random.Range(0, 6);
                Debug.Log("획득 아이템 코드 : " + getItem + " : ");
                ItemManager getItemObj = itemSample[getItem];

                if (other.GetComponent<InventoryManager>().addItem(getItemObj) == true)
                {
                    other.GetComponent<AudioSource>().clip = itemBoxSound;
                    other.GetComponent<AudioSource>().Play();
                    gameObject.SetActive(false);
                }
            }

        }
        
    }


}
