
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]  private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    //private bool grounded;
    // Start is called before the first frame update
    [SerializeField]private float speed;
    [SerializeField] private float jumpPower;
    //private float wallJumpCoolDown;
    private float HorizontalInput;
    [Header("Multiple Jump")]
    [SerializeField] private int extraJumps;
    private int jumpCounter;

    [Header("Wall Jump")]
    [SerializeField] private float WallJumpX;
    [SerializeField] private float WallJumpY;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;
    private void Awake()
    {
        // Grab the reference here...
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");

        // Flip condition while moving left and right...
        if(HorizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (HorizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }



        anim.SetBool("Run", HorizontalInput != 0);
        anim.SetBool("Grounded", IsGrounded());

        ///JUMP
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        //ADJUSTABLE JUMP HIEGHT..

        if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);
        }

        if (IsWall())
        {
            body.gravityScale = 0;
            body.velocity = Vector2.zero;
            SoundManager.instance.PlaySound(jumpSound);
        }
        else
        {
            body.gravityScale = 7;
            body.velocity = new Vector2(HorizontalInput * speed, body.velocity.y);
            if (IsGrounded())
            {
                jumpCounter = extraJumps;
            }
        }
        //}
        //if (wallJumpCoolDown > 0.2f)
        //{
        //    body.velocity = new Vector2(HorizontalInput * speed, body.velocity.y);
        //    if (IsWall() && !IsGrounded())
        //    {
        //        body.gravityScale = 0;
        //        body.velocity = Vector2.zero;
        //    }
        //    else
        //    {
        //        body.gravityScale = 7;
        //    }
        //    if (Input.GetKey(KeyCode.Space))
        //    {
        //        Jump();
        //    }
        //}
        //else
        //{
        //    wallJumpCoolDown += Time.deltaTime;
        //}
        //print(isWall());

    }
    private void Jump()
    {
        if (IsWall())
        {
            onWallJump();
        }
        else
        {
            if (IsGrounded())
            {
                SoundManager.instance.PlaySound(jumpSound);
                body.velocity = new Vector2(body.velocity.x, jumpPower);
                //anim.SetTrigger("Jump");
            }
            else if( IsWall() && !IsGrounded())
            {
                if(HorizontalInput == 0)
                {
                    body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                    transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);

                }
                else
                {
                    body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
                }
                //wallJumpCoolDown = 0;
            }

        }
        if(jumpCounter > 0)
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            jumpCounter--;
        }

    }

    private void onWallJump()
    {
        body.AddForce(new Vector2(-Mathf.Sign(transform.localScale.x) * WallJumpX, WallJumpY));
        //wallJumpCoolDown = 0;

    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0,Vector2.down,0.1f,groundLayer); 
        return raycastHit.collider != null;
    }
    private bool IsWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0,new Vector2(transform.localScale.x,0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

}
