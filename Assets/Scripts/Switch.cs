using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private bool active = false;

    [SerializeField] private bool dentro = false;

    private void Update()
    {
        if(dentro == true)
        {
        if(Input.GetKeyDown("e"))
            {
                active = true;
            }   
        }
	}

    public bool GetActive()
    {
        return active;
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
