using UnityEngine;

public class DeleteDoorV2 : MonoBehaviour
{
    [SerializeField] private SwitchV2[] switches;
    [SerializeField] private GameObject[] doors;

    private void Update()
    {
        // Verificar que los arreglos tengan la misma longitud
        if (switches.Length != doors.Length)
        {
            Debug.LogError("La cantidad de interruptores no coincide con la cantidad de puertas.");
            return;
        }

        // Iterar sobre cada par de interruptor y puerta
        for (int i = 0; i < switches.Length; i++)
        {
            // Verificar si el interruptor está activo y la puerta no ha sido destruida
            if (switches[i].GetActive() && doors[i] != null)
            {
                // Destruir la puerta
                Destroy(doors[i]);
                // Marcar la puerta como destruida para evitar que se destruya más de una vez
                doors[i] = null;
            }
        }
    }
}
