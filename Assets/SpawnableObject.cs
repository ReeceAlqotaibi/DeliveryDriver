using UnityEngine;

public class SpawnableObject
{
    public static Vector3 lastSpawnPoint {get; private set;}

    public static Vector3 firstSpawnpoint{get; set;}

    private GameObject spawnPointType;

    private GameObject gameObject;

    private static Vector3[] spawnCoordinates = 
    {
        new Vector3(0f, 29.2f), new Vector3(0f, -29.2f), new Vector3(52.542f, 0f), new Vector3(-52.542f, 0f), new Vector3(-52.542f, 14.65f), 
        new Vector3(52.542f, 14.65f),new Vector3(0f, 14.65f),  new Vector3(0f, -14.65f), new Vector3(17.06f, 0f), new Vector3(34.12f, 0f), 
        new Vector3(-34.12f, 0f), new Vector3(-17.06f, 0f), new Vector3(-34.12f, 29.2f), new Vector3(-34.12f, -29.2f), new Vector3(-17.06f, -29.2f), 
        new Vector3(-17.06f, 29.2f), new Vector3(17.06f, 29.2f), new Vector3(34.12f, 29.2f), new Vector3(17.06f, -29.2f), new Vector3(34.12f, -29.2f), 
        new Vector3(52.542f, -14.65f), new Vector3(52.542f, -14.65f)
    };
    
    public SpawnableObject(GameObject SpawnPointType, Vector3 LastSpawnPoint)
    {
        spawnPointType = SpawnPointType;
        lastSpawnPoint = LastSpawnPoint;
        CreateSpawnablObject();
    }

    private void CreateSpawnablObject()
    {
        int range = Random.Range(0, spawnCoordinates.Length);
        
        do
        {
            range = Random.Range(0, spawnCoordinates.Length);
        }
        while(spawnCoordinates[range] == lastSpawnPoint);

        gameObject = GameObject.Instantiate(spawnPointType, spawnCoordinates[range], Quaternion.identity) as GameObject;

        lastSpawnPoint = spawnCoordinates[range];
    }

    public void DestroyGameObject()
    {
        GameObject.Destroy(gameObject);
    }
}
