using UnityEngine;
using System.Collections;

public class ConstantMovement : MonoBehaviour {

	public float maxSpeed;
	public float speed;
	public float acceleeration;
	public bool previousButtonDownState;
	public Camera selectedCamera;

	private GameObject game;
	
	private float timerDesaccelerate;
	public bool outOfVision;
	// Use this for initialization
	void Start () {
		game = GameObject.Find("Game");
		
		acceleeration = -0.0005f;
		maxSpeed = 0.35f;
	}
	
	
	
	// Update is called once per frame
	void Update () {
		
		
		if(game.GetComponent<Game>().finalAnimation)
		{
			transform.Translate(new Vector3(-10.0f * Time.deltaTime, 0.0f, 0.0f));
			
			if(!this.renderer.IsVisibleFrom(this.selectedCamera) && (this.transform.position.x < this.selectedCamera.transform.position.x))
			{
				GameObject.Find ("FinalPrincess").GetComponent<PrincessFinalMovement>().startAnimation = true;
				outOfVision = true;
			}
			
			
			return;
		}
		
		if(!game.GetComponent<SwitchCharacters>().upSceneActive)
		{	
			bool buttonState = Input.GetKey(KeyCode.A);
			if(buttonState != previousButtonDownState)
			{
				speed += selectedCamera.GetComponent<ConstantFollowCamera>().xMinVelocity * 0.1f;
				timerDesaccelerate = 3.0f;	
			}
			previousButtonDownState = buttonState;
			
		}
				
		timerDesaccelerate -= Time.deltaTime;
		
		if(timerDesaccelerate < 0)
		{
			speed += acceleeration;
		}
		speed = Mathf.Max(0, speed);
		speed = Mathf.Min (maxSpeed, speed);
		
		Debug.Log (speed);
		
		transform.Translate (new Vector3 (-speed, 0.0f, 0.0f));
	}
}
