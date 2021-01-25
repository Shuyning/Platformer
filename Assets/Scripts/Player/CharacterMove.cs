using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public static Rigidbody2D rb;
    Collider2D[] groundCollisions;
    SpriteRenderer sprite;
    HealthPoint healthPoint;
    RaycastHit2D hit;

    public AudioSource source;
    public AudioClip jumpClip;
    public AudioClip walkClip;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public Animator anim;

    public float speed, jumpPower, cofSpeed;
    public float groundCheckRadius = 0.5f;
    public bool grounded, move, flip;
    public float timeWalkBtw;
    public float timeToFlash;
    public float rayDistanse;
    public  float extraJumps;
    public bool canFlash = true;
    public bool isWall;
    float startWalk, startBlick, rightSpeed, flashTimer;
    bool isFacingRight;
    public bool canJump;
    bool canWallJump;
    float valueExtraJumps;
    int getChar;

    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = true;
        flip = true;
        startBlick = 2f;
        startWalk = timeWalkBtw;
        timeWalkBtw = 0;
        flashTimer = timeToFlash;
        getChar = PlayerPrefs.GetInt("heroSelect") - 1;
        valueExtraJumps = extraJumps;

        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        healthPoint = GetComponent<HealthPoint>();
        Physics2D.queriesStartInColliders = false;
        
        rightSpeed = speed;
        cofSpeed *= speed;
        move = true;

        if(getChar != 0)
        {
            anim.enabled = false;
            Debug.Log("anim off");
        }
        else
        {
            anim.enabled = true;
            Debug.Log("anim turn" );
        }
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");

        if(x != 0)
        {
            if(move)
            {
                if(grounded)
                {
                    if(timeWalkBtw >= 0)
                    {
                        timeWalkBtw -= Time.deltaTime;
                    }
                    else if(timeWalkBtw < 0)
                    {
                        source.PlayOneShot(walkClip, 0.5f);
                        timeWalkBtw = startWalk;
                    }
                }

                anim.SetBool("isRun", true);
                rb.velocity = new Vector2(x * speed, rb.velocity.y);
            }
        }
        else
        {
            if(startBlick == 2)
            {
                anim.SetBool("isBlick", true);
                startBlick -= Time.deltaTime;
            }
            else if(startBlick >= 0)
            {
                startBlick -= Time.deltaTime;

                if(startBlick <= 1.6f)
                {
                    anim.SetBool("isBlick", false);
                }
            }
            else if(startBlick < 0)
            {
                startBlick = 2f;
            }

            anim.SetBool("isRun", false);
            timeWalkBtw = 0;
        }
        

        if(x > 0 && !isFacingRight)
        {
            flip = true;
            Flip();
        }
        else if(x < 0 && isFacingRight)
        {
            flip = false;
            Flip();
        }
    }

    private void Update() 
    {
        groundCollisions = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayer);

        if(groundCollisions.Length > 0)
        {
            grounded = true;
            anim.SetBool("isJump", false);
        }
        else
        {
            anim.SetBool("isJump", true);
            grounded = false;
        }

        if(Input.GetKey(KeyCode.LeftShift) && grounded)
        {
            speed = cofSpeed;
        }
        else
        {
            speed = rightSpeed;
        }

        if(grounded)
        {
            extraJumps = valueExtraJumps;
        }

        if(canWallJump)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }

        if(Input.GetButtonDown("Jump") && (extraJumps > 0 || canJump))
        {
            Jump(jumpPower);
            extraJumps--;
        }
        else if(Input.GetButtonDown("Jump") && extraJumps == 0 && grounded)
        {
            Jump(jumpPower);
        }

        if(Input.GetKeyDown(KeyCode.E) && canFlash)
        {
            if(flip)
            {
                Flash(Vector2.right, Vector3.right);
            }
            else
            {
                Flash(Vector2.left, Vector3.left);
            }
            
            canFlash = false;      
        }

        if(!canFlash)
        {
            timeToFlash -= Time.deltaTime;

            if(timeToFlash <= 0)
            {
                canFlash = true;
                timeToFlash = flashTimer;
            }
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(0, 180, 0);
    }

    public void Jump(float power)
    {
        source.PlayOneShot(jumpClip, 0.5f);
        rb.AddForce(Vector2.up * power, ForceMode2D.Impulse);
    }

    public void Flash(Vector2 isRight, Vector3 isVectorThee)
    {
        if(!isWall)
        {
            hit = Physics2D.Raycast(transform.position, transform.localScale.x * isRight, rayDistanse);

            if(hit.collider == null)
            {
                transform.position += transform.localScale.x * isVectorThee * rayDistanse;
            }  
            else
            {
                transform.position = hit.point;
            } 
            
        }
        else
        {
            if(!Physics2D.OverlapPoint(transform.position + transform.localScale.x * isVectorThee * rayDistanse))
            {
                transform.position += transform.localScale.x * isVectorThee * rayDistanse;
            }
            else
            {
                hit = Physics2D.Raycast(transform.position, transform.localScale.x * isRight, rayDistanse);

                if(hit.collider == null)
                {
                transform.position += transform.localScale.x * isVectorThee * rayDistanse;
                }  
                else
                {
                    transform.position = hit.point;
                } 
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(!grounded && other.gameObject.layer == 8)
        {
            move = false;
        }
        else
        {
            move = true;
        }

        if(other.gameObject.tag.Equals("Wall"))
        {
            canWallJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.tag.Equals("Wall"))
        {
            canWallJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "DropDead")
        {
            other.GetComponent<BoxCollider2D>().enabled = false;
            healthPoint.Dead();
            Debug.Log("FallDead");
        }
    }
}
