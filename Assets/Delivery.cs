using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyObjectDelay = 0f;

    [SerializeField] GameObject Package;

    [SerializeField ]GameObject Customer;

    private GameObject blueCar;

    private Driver driver;

    private void Start()
    {
        blueCar = GameObject.Find("BlueCar");
        driver = blueCar.GetComponent<Driver>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(driver.hasSpeedIncrease)
        {
            driver.moveSpeedModifier = 1f;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !driver.hasPackage)
        {
            driver.hasPackage = true;
            SpawnableObject customer = new SpawnableObject(Customer, other.transform.position);
            Destroy(other.gameObject, destroyObjectDelay);
        }
        
        if(other.tag == "Customer" &&  driver.hasPackage) 
        {
            driver.hasPackage = false;
            SpawnableObject package = new SpawnableObject(Package, other.transform.position);
            Destroy(other.gameObject, destroyObjectDelay);
        }
    }
}
