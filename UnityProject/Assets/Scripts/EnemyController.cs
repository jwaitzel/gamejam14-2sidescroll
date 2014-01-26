using UnityEngine;
using System.Collections;

public class EnemyController : CharacterController {
	
	public float timeBetweenAttacks = 1;

	private GameObject player;
	private bool hasToAttack = false;
	private bool hasToFollow = false;
	private float timePassed = 0;
	

	public override void Start() {
		life = 100;
		maxSpeed = 3;
		damage = 5;

		animator = GetComponent<Animator> ();
		player = GameObject.Find ("UpCharacter");
	}

	void FixedUpdate() {
		if (hasToFollow) {
			float movementToPlayer = Mathf.Sign (player.transform.position.x - transform.position.x) * maxSpeed;

			if ((movementToPlayer > 0 && !facingRight) || (movementToPlayer < 0 && facingRight))
				Flip();

			rigidbody2D.velocity = new Vector2 (movementToPlayer, rigidbody2D.velocity.y);
		}

		if (hasToAttack) {
			if (timePassed >= timeBetweenAttacks) {
				Attack(player);
				timePassed = 0;
			} else {
				timePassed += Time.fixedDeltaTime;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.name == "UpCharacter") {
			hasToAttack = true;
			hasToFollow = false;
		}

		if (collision.gameObject.tag == "Ground") {
			hasToFollow = true;
		}

		if (collision.gameObject.tag == "Enemy") {
			hasToFollow = false;		
		}
	}

	void OnCollisionExit2D(Collision2D collision) {
		if (collision.gameObject.name == "UpCharacter") {
			hasToAttack = false;
			hasToFollow = true;
		}

		if (collision.gameObject.tag == "Enemy") {
			hasToFollow = true;		
		}
	}

	protected override void Die() {
		base.Die ();
		hasToAttack = false;
		hasToFollow = false;
	}
}
	