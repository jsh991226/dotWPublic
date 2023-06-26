using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditUI : MonoBehaviour
{
    float gap = (18708 / 60 );
    float timer = 0;
    public GameObject GameManager;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        gap = (18708 / 3000);
        timer += Time.fixedDeltaTime;
        if (transform.localPosition.y <= 20000) {
            if (Input.GetKey(KeyCode.Space)) { gap = (18708 / 1500); }
            float temp = transform.localPosition.y + gap;
            transform.localPosition = new Vector3(transform.localPosition.x, temp, transform.localPosition.z);
        } else
        {
            GameManager.GetComponent<GameManager>().ContinueGame();
        }
    }
}
