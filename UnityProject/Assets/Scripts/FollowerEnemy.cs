using UnityEngine;
using System.Collections;

public class FollowerEnemy : MonoBehaviour {

	public GameObject followingObject;
	private Transform myTransform;
	public float moveSpeed;
	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(followingObject.transform.position.x - this.transform.position.x < 0.02f)
		{
			myTransform.Translate(-moveSpeed * Time.deltaTime * Mathf.Abs(followingObject.transform.position.x - this.transform.position.x), 0.0f, 0.0f);
		}
		
		moveSpeed += 0.001f;
	}
}
