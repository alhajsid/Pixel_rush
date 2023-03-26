using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private Button jumpButton;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle,running,jumping,falling}
    private MovementState state = MovementState.idle;

    [SerializeField] private AudioSource jumpSoundEffect;

    private bool isMoving = false;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    private void Update() 
    {

        rb.velocity = new Vector2(dirX * jumpForce, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        UpdateAnimationState();

    }

    public void Jump()
    {
        if (isGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
        }
    }

    public void MoveForward()
    {
        dirX = 1;
    }

    public void MoveBackward()
    {
        dirX = -1;
    }
    

    public void ResetDirX()
    {
        dirX = 0;
    }


    private void UpdateAnimationState()
    {

        MovementState state;
        if (dirX > 0f)
        {
            sprite.flipX = false;
            state = MovementState.running;
        }
        else if (dirX < 0f)
        {
            sprite.flipX = true;
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", ((int)state));

    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }


}


