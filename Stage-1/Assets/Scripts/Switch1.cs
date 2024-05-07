using Unity.VisualScripting;
using UnityEngine;

public class Switch1 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public static bool delete = false;

    [SerializeField] private bool dentro;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dentro == true)
        {
        if(Input.GetKeyDown("e"))
            {
                delete = true;
            }   
        }
	}	
     private OnTriggerEnter2D OnTriggerEnter2D()
	{
        dentro = true;
        return null;
    }
    private OnTriggerExit2D OnTriggerExit2D()
	{
        dentro = false;
        return null;
    }
}
