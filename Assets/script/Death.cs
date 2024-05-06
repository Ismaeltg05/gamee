using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    private static bool gameStopped = false;
    
    private void Update()
    {
    }

    public void Dead()
    {
        Time.timeScale = 0f;
        deathScreen.SetActive(true);
        gameStopped = true;
    }

    public  void Resume()
    {
        Time.timeScale = 1f;
        deathScreen.SetActive(false);
        gameStopped = false;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start");
        gameStopped = false;
    }
}
