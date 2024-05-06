using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    private bool gameStopped = false;
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameStopped)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        menu.SetActive(true);
        gameStopped = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
        gameStopped = false;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start");
        gameStopped = false;
    }

    public void Checkpoint()
    {
        Time.timeScale = 1f;
        gameStopped = false;
    }
}
