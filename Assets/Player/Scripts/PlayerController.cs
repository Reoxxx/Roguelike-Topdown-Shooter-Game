using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveInput;
    [SerializeField] private float speed = 40.0f;
    [SerializeField] private float smoothTime = 0.1f;
    private Vector2 velocity = Vector2.zero;

    private float health;
    private float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxHealth = 100;
        health = maxHealth;
        transform.position = new Vector3(2250, 2250, -1);
    }
    void FixedUpdate()
    {
        Vector2 targetVelocity = moveInput * speed;
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocity, smoothTime);
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

}
