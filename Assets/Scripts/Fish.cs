using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    public void PickUp()
    {
        Destroy(GetComponent<GameObject>());
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(GetComponent<GameObject>());
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(GetComponent<GameObject>());
    }
}
