using UnityEngine;
using System.Collections;

public class TapToStart : MonoBehaviour {

	private float interfaceBlocked;
	// Use this for initialization
	void Start () {
		interfaceBlocked = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.anyKey && interfaceBlocked < 0.0f)
		{
			Application.LoadLevel ("GameScene");
		}
		
		interfaceBlocked -= Time.deltaTime;
	}
}
