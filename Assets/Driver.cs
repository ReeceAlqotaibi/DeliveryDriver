using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 225f;
    [SerializeField] public float originalMoveSpeed = 7.5f;
    [SerializeField] public float modifiedMoveSpeed;
    public bool hasNormalSpeed = true;
    public bool hasSpeedIncrease = false;
    public bool hasSpeedDecrease = false;

    private float oldPositionX;
    private float oldPositionY;




    void Start()
    {
        oldPositionX = transform.position.x;
        oldPositionY = transform.position.y;
    }


    void Update()
    {   
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * modifiedMoveSpeed * Time.deltaTime;

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
       
}
