using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ttItemBox : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject boxModel;
    public float nowHeight;
    public bool upFlag = false;

    private List<ItemManagerTuto> itemSample = new List<ItemManagerTuto>();

    void Start()
    {
        nowHeight = boxModel.GetComponent<CapsuleCollider>().height;

        itemSample.Add(new Item6Tuto());
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
            int getItem = 0;
            ItemManagerTuto getItemObj = itemSample[getItem];
            if (other.GetComponent<ttInventoryManager>().addItem(getItemObj) == true)
            {
                //gameObject.transform.position = new Vector3(0, -100f, 0);
                gameObject.SetActive(false);
            }
        }
        
    }


}
