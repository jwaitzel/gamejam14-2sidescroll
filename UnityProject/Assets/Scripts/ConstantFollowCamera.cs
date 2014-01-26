using UnityEngine;
using System.Collections;

public class ConstantFollowCamera : MonoBehaviour {

	public GameObject objectMovement;
	public float xMinVelocity;
	
	private GameObject backgroundForMove;
	// Use this for initialization
	void Start () {
		xMinVelocity = 0.0f;
		backgroundForMove = GameObject.Find("DownBackground0");
	}
	
	// Update is called once per frame
	void Update () {

		float characterVelocity = objectMovement.GetComponent<ConstantMovement> ().speed;
		float movement;
		if (characterVelocity > xMinVelocity && objectMovement.transform.position.x > this.transform.position.x) 
		{
			movement = -xMinVelocity;
		}
		else 
		{
			movement = Mathf.Min (-characterVelocity, -xMinVelocity);
		}
		
		transform.Translate (new Vector3 (movement, 0.0f, 0.0f));
		
		foreach(Transform background in backgroundForMove.transform)
		{
			background.Translate(movement * 0.5f, 0.0f, 0.0f);
		}
		
		this.xMinVelocity += 0.0001f;
		
	}
	
}
