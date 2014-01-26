using UnityEngine;
using System.Collections;

public class PrincessFinalMovement : MonoBehaviour {

	public bool startAnimation;
	GameObject upCharacter;
	// Use this for initialization
	void Start () {
		upCharacter = GameObject.Find ("UpCharacter");
	}
	
	// Update is called once per frame
	void Update () {
		
		if(startAnimation && ((transform.position.x - upCharacter.transform.position.x) > 3.0f))
			transform.Translate( new Vector3(-3.0f * Time.deltaTime, 0.0f, 0.0f));
	
	}
}
