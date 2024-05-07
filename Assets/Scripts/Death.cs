using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    
    public void Update()
    {
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
