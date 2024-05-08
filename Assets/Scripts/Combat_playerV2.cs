using System.Collections;
using UnityEngine;

public class Combat_playerV2 : MonoBehaviour
{
    public int maxHealth;

	public int currentHealth;

	[SerializeField] private Animator animator;

	[SerializeField] private Rigidbody2D body2D;

	[SerializeField] private Move_V2 move;

	[SerializeField] private float time_loseControl = 0.5f;

	public HealthBar healthBar;

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
			Death();	
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
		body2D.constraints = RigidbodyConstraints2D.FreezeAll;
		animator.SetBool("Death", true);
	}
	public void Destroy()
	{
		Destroy(gameObject);
	}
	
}
