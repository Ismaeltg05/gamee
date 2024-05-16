using UnityEngine;

public class DeleteDoorV2 : MonoBehaviour
{
    [SerializeField] private SwitchV2[] switches;
    [SerializeField] private GameObject[] doors;
    [SerializeField] private GameDataControlerV2 gameDataController;

    private void Update()
    {
        if (switches.Length != doors.Length)
        {
            Debug.LogError("La cantidad de interruptores no coincide con la cantidad de puertas.");
            return;
        }

        for (int i = 0; i < switches.Length; i++)
        {
            if (switches[i].GetActive() && doors[i] != null)
            {
                Destroy(doors[i]);
                doors[i] = null;
            }
        }
    }

    public void SaveDoorData()
    {
        gameDataController.SaveData(doors);
    }

    public void LoadDoorData()
    {
        gameDataController.LoadData(doors);
    }
}
