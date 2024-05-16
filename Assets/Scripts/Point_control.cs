using UnityEngine;

public class Point_control : MonoBehaviour
{
    [SerializeField] private Animator animator;
        [SerializeField] private GameObject[] doors;
    [SerializeField] private GameDataControlerV2 gamedatacontroler;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            animator.SetTrigger("Active");
            gamedatacontroler.SaveData();
        }
    }

    public void SaveDoorData()
    {
        gameDataController.SaveData(doors);
    }
}
