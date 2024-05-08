using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private CombatPlayerV2 combatPlayerV2;
    
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

    public void Resume()
    {
        Time.timeScale = 1f;
        deathScreen.SetActive(false);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start");
    }
}
