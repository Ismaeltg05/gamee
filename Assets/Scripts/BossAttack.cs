using UnityEngine;

public class BossAttack : MonoBehaviour
{
	[SerializeField] private Animator animator;

	[SerializeField] private CombatPlayer combatPlayer;

	public Rigidbody2D rb2d;

	public Transform player;

	private bool see_right;

	[Header("Health")]

	[SerializeField] private Transform controller_attack;

	[SerializeField] private float radius_attack;

	[SerializeField] private int damage_attack = 15;


	[Header("HEALTHBAR")]
    //HEALTHBAR
    
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private int maxHealth;
	[SerializeField] private int currentHealth;
	[SerializeField] private GameObject bossHealth;


	// Start is called before the first frame update
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //HEALTHBAR
        currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);

	}
	// Update is called once per frame
	void Update()
	{
		currentHealth = (int)combatPlayer.health;
		healthBar.SetHealth(currentHealth);
		if (animator.GetFloat("Distance") <=20)
		{
			bossHealth.SetActive(true);
		}
		
	
		float distance_player = Vector2.Distance(transform.position, player.position);
		animator.SetFloat("distance_player", distance_player);
		if (distance_player > 2.3)
		{
			animator.SetFloat("Run",1);
		}
		else
		{
			animator.SetFloat("Run",0);
		}
	}
	
	public void Take_damage(int damage)
	{
		currentHealth -= damage;
        //HEALTHBAR
		//barradevida.Cambiarvidaactual(health);

		if(currentHealth <= 0)
		{
			animator.Play("Death",0);
		}
	}

	private void Death()
	{
		Destroy(gameObject);
	}

	public void See_player()
	{
		if((player.position.x > transform.position.x && !see_right) || (player.position.x < transform.position.x && see_right))
		{
			see_right = !see_right;
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
		}
	}
	public void attack()
	{
		Collider2D[] objects = Physics2D.OverlapCircleAll(controller_attack.position, radius_attack);

        foreach (Collider2D collider in objects)
        {
            if(collider.CompareTag("Player"))
            {
                collider.transform.GetComponent<CombatPlayerV2>().hit(damage_attack,new Vector2(0,0));
            }
        }

	}

	private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controller_attack.position, radius_attack);
    }	
	
}
