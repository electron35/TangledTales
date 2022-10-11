using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    [Range(5, 15)]
    public float maxSpeed = 10;
    public Vector2 move;
    public Vector2 targetVelocity;
    public Rigidbody2D body;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.isKinematic = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxis("Horizontal");

        ComputeVelocity();
    }

    void ComputeVelocity()
    {
        targetVelocity = move * maxSpeed;
    }

    private void FixedUpdate()
    {
        body.position += targetVelocity / 100;    
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
