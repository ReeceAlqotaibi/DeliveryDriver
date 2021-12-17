using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] public float steerSpeed = 225f;
    [SerializeField] public float originalMoveSpeed = 7.5f;
    [SerializeField] public float modifiedMoveSpeed;
    public bool hasNormalSpeed = true;
    public bool hasSpeedIncrease = false;
    public bool hasSpeedDecrease = false;


    void Start()
    {

    }


    void Update()
    {   
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * modifiedMoveSpeed * Time.deltaTime;

        // Rotates on the {x} {y} {z} axis.
        transform.Rotate(0, 0, -steerAmount);
        
        //Moves on {x} {y} {z} axis.
        transform.Translate(0, moveAmount, 0);
    }
       
}
