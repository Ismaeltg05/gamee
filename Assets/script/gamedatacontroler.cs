using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class gamedatacontroler : MonoBehaviour
{
    public GameObject player;
    public string saveFile;
    public GameData gameData = new GameData();

    private void Awake()
    {
        saveFile = Application.dataPath + "/gamedata.json";

        player = GameObject.FindGameObjectWithTag("Player");

        loadData();
    }

    private void loadData()
    {
        if(File.Exists(saveFile))
        {
            string content = File.ReadAllText(saveFile);

            gameData = JsonUtility.FromJson<GameData>(content);

            player.transform.position = gameData.position;
        // player.GetComponent<>().getHealth = gameData.health;
        // player.GetComponent<>().getStamine = gameData.stamine;
        }
        else
        {
            Debug.Log("El archivo no existe");
        }
    }
    private void saveData()
    {
        GameData newData = new GameData()
        {
            position = player.transform.position,
            // health = player.GetComponent<>().getHealth;
            // stamine = player.GetComponent<>().getStamine;
        };
        string stringJSON = JsonUtility.ToJson(newData);
        File.WriteAllText(saveFile, stringJSON);

        Debug.Log("Archivo guardado");
    }
}
