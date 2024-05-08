using System.IO;
using UnityEngine;

public class GameDataControlerV2 : MonoBehaviour
{

    public GameObject player;
    public string saveFile;
    public GameData gameData = new GameData();
    [SerializeField] private CombatPlayerV2 combatPlayerV2;

    private void Awake()
    {
        saveFile = Application.dataPath + "/gameData.json";

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void LoadData()
    {
        if(File.Exists(saveFile))
        {
            string content = File.ReadAllText(saveFile);

            Debug.Log("" + content);

            gameData = JsonUtility.FromJson<GameData>(content);

            Debug.Log("Posicion player: " + gameData.position);

            player.transform.position = gameData.position;
            combatPlayerV2.healthBar.SetHealth(gameData.health);
        }
        else
        {
            Debug.Log("File doesn't exist");
        }
    }

    public void SaveData()
    {
        GameData newData =  new()
        {
            position = player.transform.position,
            health = combatPlayerV2.currentHealth
        };

        string stringJSON = JsonUtility.ToJson(newData);

        File.WriteAllText(saveFile, stringJSON);

        Debug.Log("File Saved");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            LoadData();
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            SaveData();
        }
    }
}

//MVC

// PlayerData
    //  Vector3 Position
    //  int stamina

//PlayerController : Monobehaviour
    // Jump
    // Walk
    // TakeDamage
    // SpendStamina
        // PlayerData.Stamina -= staminaAmount

//PlayerHUD : Monobehaviour
    // Slider staminaSlider
