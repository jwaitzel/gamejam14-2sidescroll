using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private GameObject game;
	// Use this for initialization
	void Start () {
		game = GameObject.Find("Game");
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(game.GetComponent<SwitchCharacters>().upSceneActive)
			this.transform.Translate(new Vector3(Input.GetAxis ("Horizontal") * 0.1f, 0.0f, 0.0f));
	}
}
