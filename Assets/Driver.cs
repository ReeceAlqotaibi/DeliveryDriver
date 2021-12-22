using System.Collections;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 225f;
    [SerializeField] private float moveSpeed = 7.5f;
    [SerializeField] public float moveSpeedModifier = 1f;
    [SerializeField] public GameObject SpeedUpModifier;
    [SerializeField] public GameObject SpeedDownModifier;
    [SerializeField] SpawnableObject speedUp;
    [SerializeField] SpawnableObject speedDown;
    private float oldPositionX;
    private float oldPositionY;

    public bool hasPackage = false;

    private void Start()
    {
        oldPositionX = transform.position.x;
        oldPositionY = transform.position.y;

        speedUp = new SpawnableObject(SpeedUpModifier, SpawnableObject.lastSpawnPoint);
        speedDown = new SpawnableObject(SpeedDownModifier, SpawnableObject.lastSpawnPoint);

        StartCoroutine(CreateSpeedModifiers());
    }

    private void Update()
    {   

        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * (moveSpeed * moveSpeedModifier) * Time.deltaTime;

        if((oldPositionY < transform.position.y) || (oldPositionY > transform.position.y) || (oldPositionX > transform.position.x) || (oldPositionX < transform.position.x))
        {
            // Rotates on the {x} {y} {z} axis.
            transform.Rotate(0, 0, -steerAmount);
        }
        
        oldPositionX = transform.position.x;
        oldPositionY = transform.position.y;

        //Moves on {x} {y} {z} axis.
        transform.Translate(0, moveAmount, 0);
    }

    private IEnumerator CreateSpeedModifiers()
    {
        WaitForSeconds wait = new WaitForSeconds(15);
        do {

            yield return wait;

            speedUp.DestroyGameObject();
            speedDown.DestroyGameObject();

            speedUp = new SpawnableObject(SpeedUpModifier, SpawnableObject.lastSpawnPoint);
            speedDown = new SpawnableObject(SpeedDownModifier, SpawnableObject.lastSpawnPoint);
        }
        while(true);
    }

    private IEnumerator ModifySpeed(float originalSpeed, float newSpeed, bool temp)
    {
        WaitForSeconds wait = new WaitForSeconds(5);

        if(temp)
        {
            moveSpeedModifier = newSpeed;

            yield return wait;

            moveSpeedModifier = originalSpeed;
        }
        else
        {
            moveSpeedModifier = newSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Going over speed increaser at normal speed
        if(other.tag == "SpeedIncrease" && moveSpeedModifier == 1f)
        {
            StartCoroutine(ModifySpeed(1f, 1.5f, true));
            Destroy(other.gameObject, 0);
        }
        // Going over speed increaser at decreased speed
        else if(other.tag == "SpeedIncrease" && moveSpeedModifier < 1f)
        {
            StartCoroutine(ModifySpeed(0.5f, 1f, false));
            Destroy(other.gameObject, 0);
        }
        
        // Going over speed decreaser at normal speed
        if(other.tag == "SpeedDecrease" && moveSpeedModifier == 1f)
        {
            StartCoroutine(ModifySpeed(1f, 0.5f, true));
            Destroy(other.gameObject, 0);
        }

        // Going over speed decreaser at increased speed
        else if(other.tag == "SpeedDecrease" && moveSpeedModifier > 1f)
        {
            StartCoroutine(ModifySpeed(1.5f, 1f, true));
            Destroy(other.gameObject, 0);
        }
        else
        {

        }
    }
}
