using UnityEngine;

public class Delete_Door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Switch.active == true)
        {
        Destroy(gameObject);
        }
    }
}
