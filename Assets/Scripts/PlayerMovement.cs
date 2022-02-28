using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = System.Random;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player;
    // [SerializeField] private float playerMaxSpeed = 3f;
    [SerializeField] private float slowdownRate = 0.95f;
    [SerializeField] private Vector3 moveVal;
    public TextMeshProUGUI score;
    public TextMeshProUGUI health;
    private int _healthValue;
    private int _fishCount;
    [SerializeField] private GameObject pathMaker;
    private readonly Random _rnd = new Random();
    public Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        // MarkPath();
    }

    private void UpdateHealth(int change)
    {
        _healthValue += change;
        health.text = _healthValue.ToString();
    }

    private void SetScore(int increment)
    {
        _fishCount += increment;
        score.text = $"Fishes: {_fishCount}";
    }

    // Update is called once per frame
    private void Update()
    {
        animator.SetFloat("Horizontal", moveVal.x);
        animator.SetFloat("Vertical", moveVal.y);
        animator.SetFloat("Speed", GetComponent<Rigidbody2D>().velocity.sqrMagnitude);
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

    private async Task MarkPath()
    {
        while (true)
        {
            Instantiate(pathMaker, gameObject.transform);
            transform.DetachChildren();
            await Task.Delay(100);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("icepatch"))
        {
            UpdateHealth(-1);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // switch (col.tag)
        // {
        //     case "fish": PickUpFish(); break;
        // }

        if (col.CompareTag("fish"))
        {
            PickUpFish();
            col.GetComponent<Fish>().PickUp();
        }

        if (col.CompareTag("icepatch"))
        {
            col.GetComponent<IcePatchMelt>().Melt(_rnd.Next(500, 3000));
        UpdateHealth(1);
        }
    }

    private void PickUpFish()
    {
        player.mass += 0.5f;
        SetScore(1);
    }
}