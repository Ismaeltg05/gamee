using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] public static bool active = false;

    [SerializeField] private bool dentro = false;


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
                active = true;
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
