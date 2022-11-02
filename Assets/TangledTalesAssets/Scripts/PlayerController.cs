using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Diagnostics;
using UnityEngine;


public class PlayerController : PhysicsObject
{

    [Range(0.1f, 15)]
    public float maxSpeed = 2.5f;
    [Range(1, 10)]
    public float jumpTakeOffSpeed = 7f;
    [Range(0, 1)]
    public float takeOffDragSpeed = .5f;

    private Vector2 moveInput;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public GameController gameController = null;

    private float vertical;

    bool isLadder = false;
    bool isClimbing = false;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
    }

    protected override void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown("e"))
        {
            gameController.fictionalMode = !gameController.fictionalMode;
        }

        targetVelocity = Vector2.zero;

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
        UnityEngine.Debug.Log("Enter");
        ComputeVelocity();
    }

    protected override void ComputeVelocity()
    {
        moveInput = Vector2.zero;   // Reset move input

        moveInput.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * (1 - takeOffDragSpeed);
            }
        }

        if (moveInput.x > 0.01f)
            spriteRenderer.flipX = true;
        else if (moveInput.x < -0.01f)
            spriteRenderer.flipX = false;

        animator.SetBool("grounded", grounded);
        animator.SetBool("moveInputX", (Input.GetButton("Horizontal")));

        if (isClimbing)
        {
            gravityModifier = 0f;
            velocity.y = vertical * maxSpeed;
        }
        else
        {
            gravityModifier = 1f;
        }

        UnityEngine.Debug.Log("IsClimbing=" + isClimbing);


       
        
        targetVelocity = moveInput * maxSpeed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        UnityEngine.Debug.Log("Enter");
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
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
