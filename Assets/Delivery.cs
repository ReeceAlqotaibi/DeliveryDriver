using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Hit something!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package")
        {
            Debug.Log("Picked up package!");
        }
        
        if(other.tag == "Customer") 
        {
            Debug.Log("Picked up a customer!");
        }
    }
}
