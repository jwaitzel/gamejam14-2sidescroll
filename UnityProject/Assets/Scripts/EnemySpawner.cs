using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;
	public float timeBetweenSpawns = 3;
	public float spawnDistanceFromPlayer = 3;

	private float totalTimePassed;
	private float timePassedSinceLastSpawn = 0;

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("UpCharacter");
	}
	
	// Update is called once per frame
	void Update () {
		totalTimePassed += Time.deltaTime;
		timePassedSinceLastSpawn += Time.deltaTime;

		if (timePassedSinceLastSpawn >= timeBetweenSpawns) {
			spawnNewEnemy();
			timePassedSinceLastSpawn = 0;		
		}
	}

	void spawnNewEnemy() {
		float spawnDirection = Mathf.Sign(Random.Range (-10, 10));
		float randomDistance = Random.Range (0, spawnDistanceFromPlayer) * spawnDirection;
		float newEnemyPositionX = player.transform.position.x + randomDistance;

		GameObject newEnemy = (GameObject)Instantiate (enemy);
		newEnemy.transform.position = new Vector2 (newEnemyPositionX, 3);
	}
}
