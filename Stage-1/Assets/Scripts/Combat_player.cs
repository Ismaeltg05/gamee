using System;
using System.Collections;
using UnityEngine;

public class Combat_player : MonoBehaviour
{
	[SerializeField] private float health;

	private Animator animator;

	private Rigidbody2D rigidbody2D;
	private Move_V2 move;

	private int count = 0;
	[SerializeField] private float time_loseControl = 0.5f;




	// Start is called before the first frame update
	void Start()
	{
		move = GetComponent<Move_V2>();
		animator = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
	}

	public void hit(float damage)
	{
			health -= damage;
			if(health > 0)
			{
				animator.SetTrigger("Hurt");
				StartCoroutine(LoseControl());
			}
			else
			{
				animator.SetTrigger("Death");
			}
	}
	public void hit(float damage, Vector2 position)
	{
			health -= damage;
			if(health > 0)
			{
				animator.SetTrigger("Hurt");
				StartCoroutine(LoseControl());

				move.Rebound(position);
			}
			else
			{
				animator.SetTrigger("Death");
			}
	}
	private IEnumerator LoseControl()
	{
		move.canMove = false;
		yield return new WaitForSeconds(time_loseControl);
		move.canMove = true;
	}
	public void take_hit(float damage)
	{
	health -= damage;
	if(health > 0)
	{
		animator.SetTrigger("Hurt");
	}
	else
	{
	rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
	animator.SetTrigger("Death");
	}
	}

	public void take_hit(float damage, Vector2 position)
	{
		health -= damage;
		if(health <= 0)
		{
		animator.SetTrigger("Death");
		}
	}

	public void Destroy()
	{
		Destroy(gameObject);
	}
}
