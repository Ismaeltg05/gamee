using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private CombatPlayerV2 combatPlayerV2;

    [SerializeField] private GameDataControlerV2 gameDataControlerV2;
    [SerializeField] private Animator playerAnimator;
    
    public void Update()
    {
        if (combatPlayerV2.die)
        {
            Dead();
        }
    }
    
    // Start is called before the first frame update
    public void Dead()
    {
        Time.timeScale = 0f;
        deathScreen.SetActive(true);
    }

    public void Checkpoint()
    {
        gameDataControlerV2.LoadData();
        Time.timeScale = 1f;
        combatPlayerV2.die=false;
        deathScreen.SetActive(false);
        playerAnimator.SetBool("Death", false);
        playerAnimator.Play("Idle");
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start");
    }
}
