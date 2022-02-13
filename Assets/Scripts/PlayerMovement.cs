using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D player;
    // [SerializeField] private float playerMaxSpeed = 3f;
    [SerializeField] private float slowdownRate = 0.95f;
    [SerializeField] private Vector3 moveVal;
    public TextMeshProUGUI score;
    private int fishCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }
    
    void SetScore() { score.text = $"Fishes: {fishCount}"; }

    // Update is called once per frame
    private void Update()
    {
        // looks that slowdown & force multiplier & mass does the trick
        // player.velocity = Vector3.ClampMagnitude(player.velocity, playerMaxSpeed);
    }
    
    private void OnMove(InputValue value)
    {
        moveVal = value.Get<Vector2>().normalized;
    }
    
    private void FixedUpdate()
    {
        player.AddForce(moveVal * 10, ForceMode2D.Force);
        player.velocity *= slowdownRate;
        // transform.position += playerMaxSpeed * moveVal * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // switch (col.tag)
        // {
        //     case "fish": PickUpFish(); break;
        // }

        if (col.CompareTag("fish")) { PickUpFish(col.gameObject);}
        

    }

    private void PickUpFish(GameObject fish)
    {
        player.mass += 0.5f;
        Destroy(fish);
        fishCount += 1;
        SetScore();
    }
}
