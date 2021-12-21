using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPackage : MonoBehaviour
{
    [SerializeField] GameObject Package;
    [SerializeField] GameObject SpeedUp;
    [SerializeField] GameObject SpeedDown;

    private void Start()
    {
        SpawnableObject firstPackage = new SpawnableObject(Package, new Vector3(0,0));
        SpawnableObject.firstSpawnpoint = SpawnableObject.lastSpawnPoint;
        
        //SpawnableObject firstSpeedUp = new SpawnableObject(SpeedUp, SpawnableObject.lastSpawnPoint);
        //SpawnableObject firstSpeedDown = new SpawnableObject(SpeedDown, SpawnableObject.lastSpawnPoint);
    }

}
