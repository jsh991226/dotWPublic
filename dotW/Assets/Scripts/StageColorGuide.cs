using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class StageColorGuide : MonoBehaviourPunCallbacks
{


	public int thisStageNum;
	public Camera mainCamera;
	byte[,] skyColor =
	{
			{189,231,243},
			{125,213,255},
			{60,120,198},
			{99,125,139},
			{0,27,70},
			{250,224,238},
			{255,189,112}
		};


	public void changeSkyBox()
	{
		Color colorEnd = new Color32(skyColor[thisStageNum, 0], skyColor[thisStageNum, 1], skyColor[thisStageNum, 2], 255);
		mainCamera.GetComponent<SmoothFollow>().changeSkyBox(colorEnd);

	}

	private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
			if (other.GetComponent<PhotonView>().IsMine)
            {
				other.GetComponent<playerManager>().nowStage = thisStageNum;
				changeSkyBox();
			}
		}

    }
}
