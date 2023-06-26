using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomModelManager : MonoBehaviour
{
    public Renderer modelCheek;
    public Renderer modelStomach;
    public Renderer modelBody;
    public List<Renderer> modelList = new List<Renderer>();


    // Start is called before the first frame update
    void Start()
    {
        modelList.Add(modelStomach);
        modelList.Add(modelCheek);
        modelList.Add(modelBody);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 30.0f * Time.deltaTime, 0));
    }
    public void changeColor(int num, Color color)
    {
        modelList[num-1].material.color = color;
    }

}
