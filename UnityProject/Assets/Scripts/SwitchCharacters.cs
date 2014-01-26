using UnityEngine;
using System.Collections;
using System.Linq;

public class SwitchCharacters : MonoBehaviour {

	
	public bool upSceneActive = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	if(Input.GetKeyDown(KeyCode.Space))
	{
		upSceneActive = !upSceneActive;
		
		GameObject upCharacter = GameObject.Find("UpCharacter");
		GameObject downCharacter = GameObject.Find("DownCharacter");
			
		if(upSceneActive)
		{
				upCharacter.GetComponent<SpriteRenderer>().color = Color.white;
				downCharacter.GetComponent<SpriteRenderer>().color = new Color(34.0f/255.0f,34.0f/255.0f,34.0f/255.0f);	
		}
		else
		{
				downCharacter.GetComponent<SpriteRenderer>().color = Color.white;		
				upCharacter.GetComponent<SpriteRenderer>().color = new Color(34.0f/255.0f,34.0f/255.0f,34.0f/255.0f);
		}
		
	}
	
	}
}
