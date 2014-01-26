using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private GameObject game;
	private float timerWalkAgain;
	GameObject finalPrincess;
	private float finalDecisionTimer;
	private bool buttonAttackTouched;
	private string finalMenuToLoad;
	// Use this for initialization
	void Start () {
		game = GameObject.Find("Game");
		finalPrincess = GameObject.Find("FinalPrincess");
		finalDecisionTimer = 0;
		finalMenuToLoad = "WinMenu1";
	}
	
	// Update is called once per frame
	void Update () {
		
		if(transform.position.x > 515)
		{
			if(!game.GetComponent<Game>().finalAnimation)
			{
				game.GetComponent<Game>().finalAnimation = true;
				timerWalkAgain = 5.0f;
			}
			
			
			if((timerWalkAgain < 0) && ((finalPrincess.transform.position.x - transform.position.x) >= 3.0f))
			{
				transform.Translate(new Vector3(2.0f * Time.deltaTime, 0.0f, 0.0f));				

				finalDecisionTimer = 3.0f;
					

			}
			else
				timerWalkAgain -= Time.deltaTime;
			
			
			if(finalDecisionTimer > 0)
			{
				finalDecisionTimer -= Time.deltaTime;
				if(finalDecisionTimer <= 0)
				{
					Application.LoadLevel(finalMenuToLoad);
				}
			}
			
			if(Input.GetKeyDown(KeyCode.Space))
			{
				finalMenuToLoad = "WinMenu2";
			}
		}
		else
		{
		
			if(game.GetComponent<SwitchCharacters>().upSceneActive)
				this.transform.Translate(new Vector3(Input.GetAxis ("Horizontal") * 1.1f, 0.0f, 0.0f));
			}
	}
}
