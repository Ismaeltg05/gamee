using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameStart : MonoBehaviour
{
    [SerializeField] private GameDataControlerV2 gameDataControlerV2;

    public void NewGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Main");
    }
}
