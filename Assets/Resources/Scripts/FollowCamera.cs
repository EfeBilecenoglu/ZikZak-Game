using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    private Vector3 offset; 

    

    // Update is called once per frame
    void Awake()
    {
        offset = transform.position- target.position; //"transform position" is camera position
    }

    private void LateUpdate() //Method for cameras
    {
        transform.position = target.position+offset;
    }
}
