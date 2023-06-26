using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class SmoothFollowTuto : MonoBehaviour
	{

		// The target we are following
		[SerializeField]
		public Transform target;
		[SerializeField]
		private float distance = 10.0f;
		[SerializeField]
		private float height;
		[SerializeField]
		private float rotationDamping;
		[SerializeField]
		private float heightDamping;

		public bool isjump = false;
		public bool isdown = false;
		public float isDis = 0.004f;
		public float isTimeUp = 0.001f;
		public float isTimeDown= 0.001f;

		void LateUpdate()
		{
			if (!target)
				return;

			var wantedRotationAngle = target.eulerAngles.y;
			var wantedHeight = target.position.y + height;

			var currentRotationAngle = transform.eulerAngles.y;
			var currentHeight = transform.position.y;

			currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

			currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

			var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);


			transform.position = target.position;
			transform.position -= currentRotation * Vector3.forward * distance;

			// Set the height of the camera 
			transform.position = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);

			// Always look at the target
			transform.LookAt(target);
			Camera.main.fieldOfView = 55.0f;
		}
		public void corJumpUp()
        {
			Debug.Log("yes i go jump");
			isjump = true;
			StartCoroutine(jumpUp());

        }
		public void corJumpDown()
		{
			Debug.Log("yes i go down");
			isdown = true;
			StartCoroutine(jumpDown());
		}



		IEnumerator jumpUp()
		{
			int count = 1;
			while (count <= 5)
			{
				target.position = new Vector3(target.position.x , target.position.y+isDis, target.position.z);
				count++;
				yield return new WaitForSeconds(isTimeUp);
			}

		}
		IEnumerator jumpDown()
		{
			int count = 1;
			while (count <= 5)
			{
				target.position = new Vector3(target.position.x, target.position.y - isDis, target.position.z);
				count++;
				yield return new WaitForSeconds(isTimeDown);
			}
			isdown = false;
			isjump = false;
		}



	}
}