using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public float jump = 1;
    Transform target;
    //private bool doubleTap;
    // public float doubleTapTime = 0f;
    private enum State { idle, walking, jumping, falling }
    private State state = State.idle;
    private Collider2D coll;
    private float timestamp;
    private SpriteRenderer spriteRender;
    [SerializeField] private LayerMask Ground;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        target = GameObject.FindGameObjectWithTag("enemy").transform;
    }
    private void Update()
    {


        float hDirection = Input.GetAxis("Horizontal");

        //left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
            anim.SetBool("walking", true);
        }
        //right
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
            anim.SetBool("walking", true);
        }

        else
        {
            anim.SetBool("walking", false);
            //rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);// trying to stop slide
        }

        /* if (Input.GetKey(KeyCode.D)&& doubleTap) //might delete
         {
             if (Time.time - doubleTapTime < 0.4f)
             {
                 Debug.Log("Double-tapped");
                 doubleTapTime = 0f;
             }
             doubleTap = false;
         }

         else if (Input.GetKey(KeyCode.D)) && !doubleTap)
         {
             doubleTap = true;
             doubleTapTime = Time.time;
         }
         */
        if (Time.time >= timestamp && Input.GetKeyDown(KeyCode.UpArrow))//&& coll.IsTouchingLayers(Ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, 18f);
            timestamp = Time.time + jump;// allows to jump x per second
            anim.SetBool("jumping", true);
            // state = State.jumping;

        }


        else if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("crouching", true);
            rb.velocity = new Vector2(0, 0); //makes it so you don't move on x axis while crouching
        }
        else
        {
            anim.SetBool("crouching", false);
        }
        //if(Input.GetKeyDown(KeyCode.W))

        VelocityState();
        anim.SetInteger("state", (int)state);

        // transform.LookAt(target.position);

    }

    private void VelocityState()
    {
        if (state == State.jumping)
        {
            if (rb.velocity.y < .1f)
            {
                state = State.falling;
                Debug.Log("falling");
            }
        }

        else if (coll.IsTouchingLayers(Ground))
        {
            if (rb.velocity.y < .1f)
            {
                anim.SetBool("jumping", false);
                state = State.idle;
                // Debug.Log("idle");
            }
        }

        else if (Mathf.Abs(rb.velocity.x) > Mathf.Epsilon)
        {
            //moving
            state = State.walking;
        }
        else
        {
            state = State.idle;
        }
    }
}
