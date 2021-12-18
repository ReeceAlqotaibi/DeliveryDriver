using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    bool hasPackage = false;
    [SerializeField] float destroyObjectDelay = 0.1f;
    [SerializeField] Color32 hasPackageColor = new Color32(107, 224, 100, 255);
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);

    [SerializeField]  float maxSpawnX;
    [SerializeField] float maxSpawnY;

    public GameObject PackagePad;

    private void SpawnPackage()
    {
            Instantiate(PackagePad,
            new Vector3(-6.6f, 1.3f, 0), Quaternion.identity);

    }


    SpriteRenderer spriteRenderer;
    GameObject blueCar;
    Driver driver;

    private void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        //blueCar = GameObject.Find("BlueCar");
        driver = GetComponent<Driver>();
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
            SpawnPackage();
        }
        
    }
}
