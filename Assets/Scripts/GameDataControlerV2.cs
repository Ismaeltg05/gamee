using System.IO;
using UnityEngine;

public class GameDataControlerV2 : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private string saveFile;
    [SerializeField] private GameData gameData = new GameData();
    [SerializeField] private CombatPlayerV2 combatPlayerV2;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameStart gameStart;
    [SerializeField] private LoadState loadState;

    private void Awake()
    {
        saveFile = Application.dataPath + "/gameData.json";
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void LoadData(GameObject[] doors)
    { 
        if(File.Exists(saveFile))
        {
            string content = File.ReadAllText(saveFile);
            Debug.Log("" + content);
            gameData = JsonUtility.FromJson<GameData>(content);
            Debug.Log("Posicion player: " + gameData.position);
            player.transform.position = gameData.position;
            healthBar.SetHealth(gameData.health);
            for (int i = 0; i < gameData.doorStates.Length; i++)
            {
                if (gameData.doorStates[i].isDestroyed)
                {
                    Destroy(doors[i]);
                }
            }
        }
        else
        {
            Debug.Log("File doesn't exist");
        }
    }

    public void SaveData(GameObject[] doors)
    {
        saveFile = Application.dataPath + "/gameData.json";
        DoorState[] doorStates = new DoorState[doors.Length];
        for (int i = 0; i < doors.Length; i++)
        {
            doorStates[i] = new DoorState { isDestroyed = doors[i] == null };
        }
        GameData newData = new GameData
        {
            position = player.transform.position,
            health = combatPlayerV2.GetCurrentHealth(),
            doorStates = doorStates
        };
        string stringJSON = JsonUtility.ToJson(newData);
        File.WriteAllText(saveFile, stringJSON);
        Debug.Log("File Saved");
    }

    private void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.O))
        {
            LoadData();
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            SaveData();
        }
        */
    }

    [System.Serializable]
    public struct DoorState
    {
        public bool isDestroyed;
    }

    [System.Serializable]
    public class GameData
    {
        public Vector3 position;
        public int health;
        public DoorState[] doorStates;
    }
}
