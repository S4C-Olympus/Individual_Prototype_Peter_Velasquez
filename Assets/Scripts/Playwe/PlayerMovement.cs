using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 8f;
    public float acceleration = 10f;

    public float deceleration = 10f;
    public float velocityPower = 0.9f;

    public float airControl = 0.8f;

    [Header("Jump Settings")]
    public float jumpForce = 14f;
    [Tooltip("Multiplier to reduce jump height if jump is cut short")]
    public float jumpCutMultiplier = 0.5f;
    public int maxJumpCount = 1;
    public float coyoteTime = 0.1f;
    [Tooltip("Buffer Time in seconds")]
    public float jumpBufferTime = 0.1f;

    [Header("Gravity")]
    [Tooltip("Base gravity scaling when rising/jumping")]
    public float gravityScale = 4f;
    [Tooltip("Multiplier applied when falling")]
    public float fallMultiplier = 2f;
    [Tooltip("Max downward velocity")]
    public float maxFallSpeed = -20f;
    
    [Header("Ground Detection")]
    [Tooltip("Empty object transfomr for ground check")]
    public Transform groundCheck;
    [Tooltip("Ground check circle's radius")]
    public float groundCheckRadius = 0.1f;
    [Tooltip("Layer teh ground check will look for")]
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private float horizontalInput;
    private int jumpCount;
    private bool isGrounded;
    private float coyoteTimer;
    private float jumpBufferTimer;




    //Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if(isGrounded)
        {
            jumpCount = maxJumpCount;
            coyoteTimer = coyoteTime;
        } 
        else
        {
            coyoteTimer -= Time.deltaTime;
        }

        if(Input.GetButtonDown("Jump"))
        {
            jumpBufferTimer = jumpBufferTime;
        }
        else
        {
            jumpBufferTimer -= Time.deltaTime;
        }

        if(jumpBufferTimer > 0 && (coyoteTimer > 0 || jumpCount > 0))
        {
            Jump();
            jumpBufferTimer = 0;
        }

        if(Input.GetButtonDown("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y* jumpCutMultiplier);
        } 
    }

    void Jump()
    {

    }
}
