using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public void PickUp()
    {
        Debug.Log($"I am a Fish! My name is {gameObject.name}!");
        Destroy(gameObject);
    }
}
