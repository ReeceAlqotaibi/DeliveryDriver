using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] GameObject Package;
    [SerializeField ]GameObject Customer;
    private GameObject blueCar;
    private Driver driver;

    private void Start()
    {
        blueCar = GameObject.Find("BlueCar");
        driver = blueCar.GetComponent<Driver>();

        SpawnableObject firstPackage = new SpawnableObject(Package, new Vector3(0,0));
        SpawnableObject.firstSpawnpoint = SpawnableObject.lastSpawnPoint;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(driver.moveSpeedModifier > 1f)
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
            Destroy(other.gameObject);
        }
        
        if(other.tag == "Customer" &&  driver.hasPackage) 
        {
            driver.hasPackage = false;
            SpawnableObject package = new SpawnableObject(Package, other.transform.position);
            Destroy(other.gameObject);
        }
    }
}
