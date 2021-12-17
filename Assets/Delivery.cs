using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    bool hasPackage = false;
    [SerializeField] float destroyObjectDelay = 0.5f;
    [SerializeField] Color32 hasPackageColor = new Color32(107, 224, 100, 255);
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);

    SpriteRenderer spriteRenderer;
    GameObject blueCar;
    Driver driver;

    private void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        blueCar = GameObject.Find("BlueCar");
        driver = blueCar.GetComponent<Driver>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(driver.hasSpeedIncrease)
        {
            driver.moveSpeedModifier = 1f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyObjectDelay);
            
        }
        
        if(other.tag == "Customer" &&  hasPackage) 
        {
            spriteRenderer.color = noPackageColor;
            hasPackage = false;
        }
        
        // Speed boost at normal speed
        if(other.tag == "SpeedIncrease" && driver.hasNormalSpeed)
        {
            driver.moveSpeedModifier = 1.5f;
        }
        // Speed boost at decreased speed
        else if(other.tag == "SpeedIncrease" && driver.hasSpeedDecrease)
        {
            driver.moveSpeedModifier = 1f;
        }
        
        // Speed decrease at normal speed
        if(other.tag == "SpeedDecrease" && driver.hasNormalSpeed)
        {
            driver.moveSpeedModifier = 0.5f;
        }
        // Speed decrease at boosted speed
        else if(other.tag == "SpeedDecrease" && driver.hasSpeedIncrease)
        {
            driver.moveSpeedModifier = 1f;
        }
    }
}
