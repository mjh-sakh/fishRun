using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject anchor;
    private Vector3 initialOffset;
    [SerializeField] private float smoothness;

    void Start()
    {
        initialOffset = transform.position - anchor.transform.position;
    }
    
    void FixedUpdate()
    {
        var cameraPosition = anchor.transform.position + initialOffset;
        transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothness*Time.fixedDeltaTime);
    }
}
