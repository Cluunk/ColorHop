using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 20f;
    private int moveDirection;
    
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private AudioObject jumpSound;
    [SerializeField] private AudioObject deathSound;

    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
        
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void MoveInput()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            moveDirection = 0;
        else if (Input.GetKey(KeyCode.A))
        {
            moveDirection = -1;
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection = 1;
            spriteRenderer.flipX = false;
        }
        else
            moveDirection = 0;

        animator.SetBool("InAir",!OnGround());
        if (Input.GetKeyDown(KeyCode.Space) && OnGround())
            Jump();
    }

    private void Jump()
    {
        animator.SetTrigger("Jump");
        rb.velocity = Vector2.up * jumpForce;
        if (jumpSound)
            Instantiate(jumpSound, transform.position, Quaternion.identity);
    }

    private void Move()
    {
        animator.SetBool("Moving", moveDirection != 0);
        rb.velocity = new Vector2(moveDirection * speed * Time.fixedDeltaTime, rb.velocity.y);
    }
    
    private bool OnGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    public void TakeDamage()
    {
        transform.position = GameManager.Instance.CurrentLevel.LevelStart.position;
        rb.velocity = Vector2.zero;
        if (deathSound)
            Instantiate(deathSound, transform.position, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
