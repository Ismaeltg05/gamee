using UnityEngine;

public class SwitchV2 : MonoBehaviour
{
    [SerializeField] private bool active = false;
    [SerializeField] private bool dentro = false;

    private void Update()
    {
        if (dentro && Input.GetKeyDown(KeyCode.E))
        {
            active = !active; // Cambiar el estado del interruptor al presionar la tecla E
        }
    }

    public bool GetActive()
    {
        return active;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        dentro = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        dentro = false;
    }
}