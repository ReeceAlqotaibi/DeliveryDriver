using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 225f;
    [SerializeField] public float moveSpeed = 7.5f;
    [SerializeField] public float moveSpeedModifier = 1f;

    private float oldPositionX;
    private float oldPositionY;

    public bool hasSpeedIncrease = false;
    public bool hasSpeedDecrease = false;
    public bool hasNormalSpeed = true;

    void Start()
    {
        oldPositionX = transform.position.x;
        oldPositionY = transform.position.y;
    }

    void Update()
    {   
        if(moveSpeedModifier == 1)
        {
            hasNormalSpeed = true;
            hasSpeedIncrease = false;
            hasSpeedDecrease = false;
        }
        else if(moveSpeedModifier > 1)
        {
            hasNormalSpeed = false;
            hasSpeedIncrease = true;
            hasSpeedDecrease = false;
        }
        else
        {
            hasNormalSpeed = false;
            hasSpeedIncrease = false;
            hasSpeedDecrease = true;
        }

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

    private void OnTriggerEnter2D(Collider2D other) {
        // Speed boost at normal speed
        if(other.tag == "SpeedIncrease" && this.hasNormalSpeed)
        {
            this.moveSpeedModifier = 1.5f;
        }
        // Speed boost at decreased speed
        else if(other.tag == "SpeedIncrease" && this.hasSpeedDecrease)
        {
            this.moveSpeedModifier = 1f;
        }
        
        // Speed decrease at normal speed
        if(other.tag == "SpeedDecrease" && this.hasNormalSpeed)
        {
            this.moveSpeedModifier = 0.5f;
        }
        // Speed decrease at boosted speed
        else if(other.tag == "SpeedDecrease" && this.hasSpeedIncrease)
        {
            this.moveSpeedModifier = 1f;
        }
    }
       
}
