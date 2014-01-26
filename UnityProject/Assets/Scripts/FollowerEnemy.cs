using UnityEngine;
using System.Collections;

public class FollowerEnemy : MonoBehaviour {

	public GameObject followingObject;
	private Transform myTransform;
	public float moveSpeed;
	GameObject game;
	bool escaping;
	// Use this for initialization
	void Start () {
		myTransform = transform;
		game = GameObject.Find ("Game");
	}
	
	// Update is called once per frame
	void Update () {
	
	if(game.GetComponent<Game>().finalAnimation)
	{
		transform.Translate(new Vector3(4.0f * Time.deltaTime, 0.0f, 0.0f));
		
		if(!escaping)
		{
			transform.localScale = new Vector3(-1.0f * transform.localScale.x, transform.localScale.y, transform.localScale.z);
			escaping = true;
		}
		
		return;
	}
		if(followingObject.transform.position.x - this.transform.position.x < 0.02f)
		{
			myTransform.Translate(-moveSpeed * Time.deltaTime * Mathf.Abs(followingObject.transform.position.x - this.transform.position.x), 0.0f, 0.0f);
		}
		
		moveSpeed += 0.001f;
	}
}
