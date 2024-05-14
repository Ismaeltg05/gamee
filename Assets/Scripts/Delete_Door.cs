using UnityEngine;

public class Delete_Door : MonoBehaviour
{

    [SerializeField] private Switch Switch;
    private void Update()
    {
        if(Switch.GetActive() == true)
        {
        Destroy(gameObject);
        }
    }
}
