using UnityEngine;
using System.Collections;

public class ObjectFollower : MonoBehaviour {

	public Camera selectedCamera;
	public float cameraThreshold;
	private GameObject backgroundForMove;
	private GameObject game;
	// Use this for initialization
	void Start () {
		game = GameObject.Find("Game");
		backgroundForMove = GameObject.Find("UpBackground0");
	}
	
	
	// Update is called once per frame
	void Update () {

		if(game.GetComponent<Game>().finalAnimation)
		{
			if(selectedCamera.transform.position.x < 525.0f)
				selectedCamera.transform.Translate(new Vector3(5.0f * Time.deltaTime, 0.0f, 0.0f));
				
		}


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
