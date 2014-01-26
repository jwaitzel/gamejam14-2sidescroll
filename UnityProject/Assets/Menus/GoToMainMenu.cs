using UnityEngine;
using System.Collections;

public class GoToMainMenu : MonoBehaviour {


	private float interfaceBlocked;
	// Use this for initialization
	void Start () {
		interfaceBlocked = 8.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	if(Input.anyKeyDown && interfaceBlocked < 0.0f)
	{
			Application.LoadLevel("InitialScene");
	}
	
	interfaceBlocked -= Time.deltaTime;
	
	}
}
