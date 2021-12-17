using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    //bool hasPackage = false;
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Hit something!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject BlueCar = GameObject.Find("BlueCar");
        Driver driver = BlueCar.GetComponent<Driver>();

        if (other.tag == "Package")
        {
            Debug.Log("Picked up package!");
        }
        
        if(other.tag == "Customer") 
        {
            Debug.Log("Picked up a customer!");
        }
        
        // Speed boost at normal speed
        if(other.tag == "SpeedIncrease" && driver.hasNormalSpeed == true)
        {
            driver.hasSpeedIncrease = true;
            driver.hasNormalSpeed = false;
            driver.modifiedMoveSpeed = driver.originalMoveSpeed * 1.5f;
        }
        // Speed boost at decreased speed
        else if(other.tag == "SpeedIncrease" && driver.hasSpeedDecrease == true)
        {
            driver.hasNormalSpeed = true;
            driver.hasSpeedDecrease = false;
            driver.modifiedMoveSpeed = driver.originalMoveSpeed;
        }
        
        // Speed decrease at normal speed
        if(other.tag == "SpeedDecrease" && driver.hasNormalSpeed == true)
        {
            driver.hasNormalSpeed = false;
            driver.hasSpeedDecrease = true;
            driver.modifiedMoveSpeed = driver.originalMoveSpeed / 1.5f;
        }
        // Speed decrease at boosted speed
        else if(other.tag == "SpeedDecrease" && driver.hasSpeedIncrease == true)
        {
            driver.hasNormalSpeed = true;
            driver.hasSpeedDecrease = false;
            driver.hasSpeedIncrease = false;
            driver.modifiedMoveSpeed = driver.originalMoveSpeed;
        }
    }

}
