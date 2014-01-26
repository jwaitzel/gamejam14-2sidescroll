using UnityEngine;
using System.Collections;

public class ConstantFollowCamera : MonoBehaviour {

	public GameObject objectMovement;
	public float xMinVelocity;
	
	private GameObject backgroundForMove;
	GameObject game;
	float finalSpeed;
	GameObject downCharacter;
	// Use this for initialization
	void Start () {
		xMinVelocity = 0.0f;
		backgroundForMove = GameObject.Find("DownBackground0");
		game = GameObject.Find ("Game");
		finalSpeed = 0.0f;
		downCharacter = GameObject.Find ("DownCharacter");
		
	}
	
	// Update is called once per frame
	void Update () {
		
		float characterVelocity = objectMovement.GetComponent<ConstantMovement> ().speed;
		float movement;
		
		if(game.GetComponent<Game>().finalAnimation)
		{
			if(finalSpeed == 0.0f)
				finalSpeed = characterVelocity;
			
				if(finalSpeed > 0.0f)
					finalSpeed -= 0.05f * Time.deltaTime;
			
			movement = finalSpeed;
			
			if(!downCharacter.GetComponent<ConstantMovement>().outOfVision)
				transform.Translate (new Vector3 (movement, 0.0f, 0.0f));
			else
				return;
		}
		else
		{
			if (characterVelocity > xMinVelocity && objectMovement.transform.position.x > this.transform.position.x) 
			{
				movement = -xMinVelocity;
			}
			else 
			{
				movement = Mathf.Min (-characterVelocity, -xMinVelocity);
			}
			
			transform.Translate (new Vector3 (movement, 0.0f, 0.0f));
		}
			
		
		foreach(Transform background in backgroundForMove.transform)
		{
			background.Translate(movement * 0.5f, 0.0f, 0.0f);
		}
		
		this.xMinVelocity += 0.0001f;
		
	}
	
}
