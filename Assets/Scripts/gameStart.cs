using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    [SerializeField] private GameDataControlerV2 gameDataControlerV2;

    [SerializeField] private MoveV2 moveV2;

    public void NewGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Main");
    }
}
