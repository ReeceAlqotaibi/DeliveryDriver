using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingtoFollow;

    // Happens at the end of the main update cycle. https://docs.unity3d.com/Manual/ExecutionOrder.html
    void LateUpdate()
    {
        transform.position = thingtoFollow.transform.position + new Vector3(0,0,-10);
    }
}
