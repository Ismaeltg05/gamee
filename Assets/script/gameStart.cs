using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameStart : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Main");
    }
}
