using System.Collections;
using UnityEngine;

public class Plataform_fall : MonoBehaviour
{
	[SerializeField] private float time_wait;

	private Rigidbody2D rigidbody2D;

	[SerializeField] private float speed_rotation;

	private Animator animator;

	private bool fall = false;


	// Start is called before the first frame update
	void Start()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	void Update()
	{
		if(fall)
		{
			Vector3 s = new Vector3(0,0, -speed_rotation * Time.deltaTime);
			transform.Rotate(s);
		}
	}
	private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			StartCoroutine(falling(other));
		}
		if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
			Destroy(gameObject);
		}
	}
	private IEnumerator falling(Collision2D other)
	{
		//animator.SetTrigger("Desactivate");
		yield return new WaitForSeconds(time_wait);
		fall = true;
		Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(),other.transform.GetComponent<Collider2D>());
		rigidbody2D.constraints = RigidbodyConstraints2D.None;
		rigidbody2D.AddForce(new Vector2(0.1f, 0));
		//rigidbody2D.AddForce(Vector.right * 0.1);
	}
}
