using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterCollision : MonoBehaviour
{

    public AudioSource flameDeath;

    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            flameDeath.Play();
            Application.Quit();
        }
            

    }
}
