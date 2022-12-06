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

    [Range(50, 1080)]
    public int circleRadius = 750;
    public bool fictionalMode = false;

    private Vector2 moveInput;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Collider2D playerCollider;

    public GameController gameController = null;

    private float vertical;

    bool isLadder = false;
    bool isClimbing = false;

    [SerializeField]
    public bool CanSwap = true;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<Collider2D>();
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
            if (CanSwap)
            {
                gameController.fictionalMode = !gameController.fictionalMode;
            }
            else
            {
                UnityEngine.Debug.Log("NANNANANANNANNAN");
            }
        }

        targetVelocity = Vector2.zero;

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
        ComputeVelocity();
    }

    protected override void ComputeVelocity()
    {
        moveInput = Vector2.zero;   // Reset move input

        moveInput.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
            gameObject.transform.SetParent(null);
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * (1 - takeOffDragSpeed);
            }
        }

        if (moveInput.x > 0.01f)
        {
            spriteRenderer.flipX = true;
            gameObject.transform.SetParent(null);
        }
        else if (moveInput.x < -0.01f)
        {
            spriteRenderer.flipX = false;
            gameObject.transform.SetParent(null);
        }

        animator.SetBool("jump", Input.GetButtonDown("Jump"));
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
        targetVelocity = moveInput * maxSpeed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IsLadder ladder))
        {
            if (ladder.LadderActive)
            {
                ladder.pc = this;
                isLadder = true;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IsLadder ladder))
        {
            if (ladder.LadderActive)
            {
                stopClimb();
            }
                
        }
    }

    public void stopClimb()
    {
        isLadder = false;
        isClimbing = false;
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
