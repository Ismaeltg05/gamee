using System.Collections;
using UnityEngine;

public class Combat_playerV2 : MonoBehaviour
{
    public int maxHealth;
	public int currentHealth;

	private Animator animator;

	private Rigidbody2D body2D;
	private Move_V2 move;

	private int count = 0;
	[SerializeField] private float time_loseControl = 0.5f;

	public HealthBar healthBar;

	// Start is called before the first frame update
	void Start()
	{
		move = GetComponent<Move_V2>();
		animator = GetComponent<Animator>();
		body2D = GetComponent<Rigidbody2D>();
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}
	// Update is called once per frame
	void Update()
	{
		
	}

	public void hit(int damage)
	{
		CineMachine_Shake.instance.Move_Camera(4, 4, 0.5f);
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
		
		if(currentHealth > 0)
		{
			animator.SetTrigger("Hurt");
			StartCoroutine(LoseControl());
		}
		else
		{
			animator.SetTrigger("Death");
			 Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("Enemies"),true);
		}
	}
	public void hit(int damage, Vector2 position)
	{
		CineMachine_Shake.instance.Move_Camera(4, 4, 0.5f);

		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
		if(currentHealth > 0)
		{
			animator.SetTrigger("Hurt");
			StartCoroutine(LoseControl());
			move.Rebound(position);
		}
		else
		{
			animator.SetTrigger("Death");
			 Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("Enemies"),true);
		}
	}
	private IEnumerator LoseControl()
	{
		move.canMove = false;
		yield return new WaitForSeconds(time_loseControl);
		move.canMove = true;
	}
	public void take_hit(int damage)
	{
		CineMachine_Shake.instance.Move_Camera(4, 4, 0.5f);
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
		
		if(currentHealth > 0)
		{
			animator.SetTrigger("Hurt");
		}
		else
		{
			body2D.constraints = RigidbodyConstraints2D.FreezeAll;
			animator.SetTrigger("Death");
			 Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("Enemies"),true);
			 
		}
	}

	public void take_hit(int damage, Vector2 position)
	{
		CineMachine_Shake.instance.Move_Camera(4, 4, 0.5f);
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);

		if(currentHealth <= 0)
		{
			animator.SetTrigger("Death");
			 Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("Enemies"),true);

		}
	}

	public void Destroy()
	{
		Destroy(gameObject);
	}
	
}

