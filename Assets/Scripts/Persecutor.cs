using UnityEngine;

public class Persecutor : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] private float distance;

    public Vector3 start_point;

    [SerializeField] private Animator animator;

    private bool see_right;

   
    // Update is called once per frame
    void Update()
    {
        start_point = transform.position;
        distance = Vector2.Distance(transform.position, player.position);
        animator.SetFloat("Distance", distance);
        animator.SetInteger("Hability",Random.Range(0,500));
    }

    public void Spin(Vector3 objetive)
    {
       if((objetive.x > transform.position.x && !see_right) || (objetive.x < transform.position.x && see_right))
		{
			see_right = !see_right;
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
		}
    }
}
