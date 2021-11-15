using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    GameObject gamemanager2D;
    private void Awake()
    {
        gamemanager2D = GameObject.FindGameObjectWithTag("GameManager2D");
       
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo" )
        {
            gamemanager2D.GetComponent<GameManager2D>().vida -= 1;
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        if ( collision.gameObject.tag == "Trampa")
        {
            gamemanager2D.GetComponent<GameManager2D>().vida -= 1;
        }
    }
}
