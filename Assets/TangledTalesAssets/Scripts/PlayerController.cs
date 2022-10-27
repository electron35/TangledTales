using System.Collections;
using System.Collections.Generic;
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

    public GameController gameController = null;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
    }

    protected override void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            gameController.fictionalMode = !gameController.fictionalMode;
        }

        targetVelocity = Vector2.zero;
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
