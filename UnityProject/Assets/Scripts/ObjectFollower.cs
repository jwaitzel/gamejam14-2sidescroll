using UnityEngine;
using System.Collections;

public class ObjectFollower : MonoBehaviour {

	public Camera selectedCamera;
	public float cameraThreshold;
	private GameObject backgroundForMove;
	// Use this for initialization
	void Start () {
		backgroundForMove = GameObject.Find("UpBackground0");
	}
	
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x > selectedCamera.transform.position.x + cameraThreshold) 
		{
			Vector3 oldPosition = selectedCamera.transform.position;
			selectedCamera.transform.position = new Vector3(transform.position.x - cameraThreshold,
			                                                selectedCamera.transform.position.y,
			                                                selectedCamera.transform.position.z); 
			float movement = oldPosition.x - selectedCamera.transform.position.x;
			

			foreach(Transform background in backgroundForMove.transform)
			{
				background.Translate(-movement * 0.5f, 0.0f, 0.0f);
			}
		}
	
	}
}
