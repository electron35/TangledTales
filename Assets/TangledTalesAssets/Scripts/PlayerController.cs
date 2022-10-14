using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : PhysicsObject
{

    [Range(0.1f, 15)]
    public float maxSpeed = 10;

    private Vector2 moveInput;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");

        if (moveInput.x > 0.01f)
            spriteRenderer.flipX = false;
        else if (moveInput.x < -0.01f)
            spriteRenderer.flipX = true;

        ComputeVelocity();
    }

    void ComputeVelocity()
    {
        targetVelocity = moveInput * maxSpeed;
    }

    public enum JumpState
    {
        Grounded,
        PrepareToJump,
        Jumping,
        InFlight,
        Landed
    }
}
