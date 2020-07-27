using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField, Header("Movement")] float moveSpeed;
    [SerializeField, Range(0,1)] float moveDampen;
#pragma warning restore 0649

    Vector2 moveVelocity, moveTarget, moveCurrent;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;

    bool isInDialog = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // If in dialog - early out
        if (isInDialog) return;

        GetMovement();
        Interact();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void GetMovement()
    {
        // Target movement input
        moveTarget.x = Input.GetAxisRaw("Horizontal");
        moveTarget.y = Input.GetAxisRaw("Vertical");

        // Normalize and set magnitude
        moveTarget = moveTarget.normalized * moveSpeed;
    }

    void Move()
    {        
        moveCurrent = Vector2.SmoothDamp(moveCurrent, moveTarget, ref moveVelocity, moveDampen);
        float speed = moveCurrent.sqrMagnitude;

        // Add velocity to rb
        Vector2 newPos = rb.position + moveCurrent * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
        
        // Set animator
        animator.SetFloat("Movement Speed", speed);

        // Flip sprite
        spriteRenderer.flipX = moveCurrent.x < 0;
    }

    void Interact()
    {
        // Check input
        if (Input.GetButtonDown("Jump"))
        {
            // Check if NPC is active and not already talking
            if(NPC.ActiveNPC && !isInDialog)
            {
                // Start dialog
                isInDialog = true;
                DialogUI.Instance.Show();
            }
        }
    }
}
