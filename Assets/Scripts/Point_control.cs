using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point_control : MonoBehaviour
{
    //private Animator animator;
    //public bool animationDone = false;
    
    public GameDataControlerV2 gamedatacontroler;


    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //animator.SetTrigger("Active");
            //ControllerGames.instance.LastPoint_control(gameObject);
            gamedatacontroler.SaveData();
        }
    }
}
