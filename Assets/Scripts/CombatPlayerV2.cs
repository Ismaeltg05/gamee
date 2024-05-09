using System.Collections;
using UnityEngine;

public class CombatPlayerV2 : MonoBehaviour
{
    public int maxHealth;

	public int currentHealth;

	[SerializeField] private Animator animator;

	[SerializeField] private Rigidbody2D body2D;

	[SerializeField] private MoveV2 move;

	[SerializeField] private float time_loseControl = 0.5f;

	public HealthBar healthBar;
	public bool die = false;


	// Start is called before the first frame update
	private void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}
	// Update is called once per frame
	private void Update()
	{
		
	}
	public void hit(int damage, Vector2 position)
	{
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
		move.Rebound(position);

		if(currentHealth > 0)
		{
			animator.Play("Hurt",0);
			StartCoroutine(LoseControl());
		}
		else
		{
			animator.Play("Death");
		}
	}
	private IEnumerator LoseControl()
	{
		move.canMove = false;
		yield return new WaitForSeconds(time_loseControl);
		move.canMove = true;
	}
	
	private void Death()
	{
		animator.SetBool("Death", true);
		die = true;
	}
	public void Destroy()
	{
		Destroy(gameObject);

	}
	
}

