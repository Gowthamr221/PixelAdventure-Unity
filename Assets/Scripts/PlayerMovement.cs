using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerObj;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer playerSprite;
    private float dirX=0f;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField]private float moveSpeed = 7f;
    [SerializeField]private float jumpSpeed = 14f;
    [SerializeField] private LayerMask jumpableGround;
    private enum MovementState { idle,running,jumping,falling}
    
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        dirX = Input.GetAxisRaw("Horizontal");
        playerObj.velocity = new Vector2(dirX * moveSpeed, playerObj.velocity.y);
        UpdateAnimationState();  
        if (Input.GetButtonDown("Jump") && isGrounded()==true) {
            playerObj.velocity = new Vector2(playerObj.velocity.x, jumpSpeed);
            jumpSoundEffect.Play();
        }
        

    }

    private void UpdateAnimationState() {
        MovementState state;
        if (dirX > 0f )
        {
            state = MovementState.running;
            playerSprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            playerSprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (playerObj.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (playerObj.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
           
      
        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded() {

        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f,jumpableGround);
    }
}
