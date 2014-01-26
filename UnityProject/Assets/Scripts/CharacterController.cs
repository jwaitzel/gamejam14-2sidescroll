using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	public float life = 100;
	public float damage = 50;
	public float maxSpeed = 10;
	public bool facingRight = true;

	public GameObject game;

	protected Animator animator;

	// Use this for initialization
	public virtual void Start () {
		animator = GetComponent<Animator> ();
		game = GameObject.Find("Game");
	}

	protected void Attack(GameObject attackegGameObject) {
		animator.SetTrigger("attack");

		if (attackegGameObject != null)
			attackegGameObject.SendMessage ("ApplyDamage", damage);
	}

	protected void ApplyDamage(float damage) {
		life -= damage;
		
		if (life <= 0) {
			Die ();
		}
	}

	protected void Flip() {
		facingRight = !facingRight;
		Vector2 flipScale = transform.localScale;
		flipScale.x *= -1;
		transform.localScale = flipScale;
	}
	
	protected virtual void Die (){
		life = 0;
		animator.SetBool ("dead", true);
	}

	public void RemoveFromScene() {
		Destroy(this.gameObject);
	}
}
