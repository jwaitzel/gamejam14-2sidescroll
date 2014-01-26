using UnityEngine;
using System.Collections;

public class PlayerController : CharacterController {
	
	public float jumpForce = 500;

	GameObject enemyToAttack;
	
	// Use this for initialization
	public override void Start () {
		base.Start ();

		life = 100;
		damage = 50;
		maxSpeed = 10;
	}

	void FixedUpdate() {
		if(game.GetComponent<SwitchCharacters>().upSceneActive) {
			float move = Input.GetAxis ("Horizontal");

			animator.SetFloat ("speed", Mathf.Abs (move));

			rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

			if ((move > 0 && !facingRight) || (move < 0 && facingRight))
				Flip ();

		}
	}

	void Update() {
		if (Input.GetButtonDown("Jump")) {
			rigidbody2D.AddForce (new Vector2 (0, jumpForce));
		}

		if (Input.GetButtonDown("Fire1")) {
			Attack(enemyToAttack);
		}
	}

	//Colisiones
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Enemy") {
			enemyToAttack = collision.gameObject;
		}
	}

	void OnCollisionExit2D(Collision2D collision) {
		if (collision.gameObject.tag == "Enemy") {
			enemyToAttack = null;
		}
	}
}
