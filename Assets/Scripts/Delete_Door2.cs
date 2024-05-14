using UnityEngine;

public class Delete_Door2 : MonoBehaviour
{
    [SerializeField] private Switch1 switch1;
    void Update()
    {
        if(switch1.GetDelete() == true)
        {
        Destroy(gameObject);
        }
    }
}
