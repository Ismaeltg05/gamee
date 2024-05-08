using UnityEngine;

public class Point_control : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public bool animationDone = false;
    
    public GameDataControlerV2 gamedatacontroler;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            animator.SetTrigger("Active");
            gamedatacontroler.SaveData();
        }
    }
}
