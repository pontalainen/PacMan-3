using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]


public class PacMan : MonoBehaviour
{
    public GameObject wallcheckObjUp;
    public GameObject wallcheckObjDown;
    public GameObject wallcheckObjRight;
    public GameObject wallcheckObjLeft;
    public bool wallcheckUp;
    public bool wallcheckDown;
    public bool wallcheckLeft;
    public bool wallcheckRight;

    public Animator animator;

    private Rigidbody2D rb;
    private readonly float speed = 25;
    public string lastDir;

    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        // Physics enginge will not rotate PacMan
        rb.freezeRotation = true;
        // remove gravity
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        wallcheckUp = wallcheckObjUp.GetComponent<Crash>().CrashVar;
        wallcheckDown = wallcheckObjDown.GetComponent<Crash>().CrashVar;
        wallcheckLeft = wallcheckObjLeft.GetComponent<Crash>().CrashVar;
        wallcheckRight = wallcheckObjRight.GetComponent<Crash>().CrashVar;

        //setting the wanted direction with input buttons
        if (Input.GetKey(KeyCode.W))
        {
            lastDir = "Up";
            Debug.Log(lastDir);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            lastDir = "Right";
            Debug.Log(lastDir);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            lastDir = "Down";
            Debug.Log(lastDir);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            lastDir = "Left";
            Debug.Log(lastDir);
        }

        //movement in wanted direction when possible
        if (lastDir == "Up" && wallcheckUp == false)
        {
            rb.velocity = new Vector2(0, speed);
            animator.Play("Pac_Up");
        }

        else if (lastDir == "Down" && wallcheckDown == false)
        {
            rb.velocity = new Vector2(0, -speed);
            animator.Play("Pac_Down");
        }

        else if (lastDir == "Left" && wallcheckLeft == false)
        {
            rb.velocity = new Vector2(-speed, 0);
            animator.Play("Pac_Left");
        }

        else if (lastDir == "Right" && wallcheckRight == false)
        {
            rb.velocity = new Vector2(speed, 0);
            animator.Play("Pac_Right");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Crash 1");
        if (collision.gameObject.name.StartsWith("maze"))
        {
            Debug.Log("Crash 2");
            if (lastDir == "Right")
            {
                rb.position = rb.position + new Vector2(-0.2f, 0);
                Debug.Log("Flyttat");
                animator.Play("Pac_Idle_Right");
            }

            else if (lastDir == "Left")
            {
                rb.position = rb.position + new Vector2(0.2f, 0);
                Debug.Log("Flyttat");
                animator.Play("Pac_Idle_Left");
            }

            else if (lastDir == "Up")
            {
                rb.position = rb.position + new Vector2(0, -0.2f);
                Debug.Log("Flyttat");
                animator.Play("Pac_Idle_Up");
            }

            else if (lastDir == "Down")
            {
                rb.position = rb.position + new Vector2(0, 0.2f);
                Debug.Log("Flyttat");
                animator.Play("Pac_Idle_Down");
            }
        }

        if (collision.gameObject.name.StartsWith("Right"))
        {
            rb.position = new Vector2(-52.7f, 4f);
        }

        else if (collision.gameObject.name.StartsWith("Left"))
        {
            rb.position = new Vector2(52.8f, 3.6f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Kolliderar");
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name.StartsWith("Dot"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Kolli");
        }
    }

}