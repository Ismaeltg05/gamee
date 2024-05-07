using System.Threading;
using UnityEngine;

public class hit : MonoBehaviour
{
    [SerializeField] private int damage;

	private Animator animator;

	void Start()
	{
		animator = GetComponent<Animator>();
	}
    private void OnCollisionEnter2D (Collision2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			other.gameObject.GetComponent<Combat_playerV2>().hit(damage, other.GetContact(0).normal);
		}
	}	
}
