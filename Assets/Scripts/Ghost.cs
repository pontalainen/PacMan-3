using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]


public class Ghost : MonoBehaviour
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
    private readonly float speed = 30;
    public Vector2 lastDir;
    private static System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Physics enginge will not rotate PacMan
        rb.freezeRotation = true;
        // remove gravity
        rb.gravityScale = 0;
        // slumpa 0 eller 1
        // 0 -> vänster
        // 1 -> höger
        int dirInt = random.Next(0, 1);

        if (dirInt == 0)
        {
            rb.velocity = new Vector2(speed, 0);
            lastDir = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
            lastDir = new Vector2(-speed, 0);
        }

    }

    bool IsEqual(Vector2 v1, Vector2 v2)
    {
        return v1.x - v2.x < 0.01 && v1.y - v2.y < 0.01;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        wallcheckUp = wallcheckObjUp.GetComponent<Crash>().CrashVar;
        wallcheckDown = wallcheckObjDown.GetComponent<Crash>().CrashVar;
        wallcheckLeft = wallcheckObjLeft.GetComponent<Crash>().CrashVar;
        wallcheckRight = wallcheckObjRight.GetComponent<Crash>().CrashVar;
        //movement in wanted direction when possible
        if (wallcheckUp == false || wallcheckDown == false || wallcheckLeft == false || wallcheckRight == false)
        {
            List<Vector2> possibleList = new List<Vector2>();
            if (wallcheckUp == false && !IsEqual(lastDir, new Vector2(0, speed)))
            {
                possibleList.Add(new Vector2(0, speed));
                Debug.Log("Kan gå upp");
            }

            if (wallcheckDown == false && !IsEqual(lastDir, new Vector2(0, -speed)))
            {
                possibleList.Add(new Vector2(0, -speed));
                Debug.Log("Kan gå ned");
            }

            if (wallcheckLeft == false && !IsEqual(lastDir, new Vector2(-speed, 0)))
            {
                possibleList.Add(new Vector2(-speed, 0));
                Debug.Log("Kan gå vänster");
            }

            if (wallcheckRight == false && IsEqual(lastDir, new Vector2(speed, 0)))
            {
                possibleList.Add(new Vector2(speed, 0));
                Debug.Log("Kan gå höger");
            }


            // *** Denna funkar inte, Ghost väljer att gå uppåt eller nedåt innan han ***
            // *** väljer att gå höger/vänster som han ska vid start ***

            //if (possibleList.Count > 1)
            //{
            //    int turnRandomizer = random.Next(0, possibleList.Count - 1);
            //    rb.velocity = possibleList[turnRandomizer];
            //    lastDir = possibleList[turnRandomizer];
            //    Debug.Log("Går åt" + lastDir);
            //}
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("Crash 1");
        if (collision.gameObject.name.StartsWith("maze"))
        {
            rb.position = rb.position - lastDir / speed * 0.2f;
        }
    }
}

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        // Debug.Log("Crash 1");
//        if (collision.gameObject.name.StartsWith("maze"))
//        {
//            //Debug.Log("Crash 2");
//            if (lastDir == "Right")
//            {
//                rb.position = rb.position + new Vector2(-0.2f, 0);
//                //Debug.Log("Flyttat");
//                animator.Play("Pac_Idle_Right");
//            }

//            else if (lastDir == "Left")
//            {
//                rb.position = rb.position + new Vector2(0.2f, 0);
//                //Debug.Log("Flyttat");
//                animator.Play("Pac_Idle_Left");
//            }

//            else if (lastDir == "Up")
//            {
//                rb.position = rb.position + new Vector2(0, -0.2f);
//                //Debug.Log("Flyttat");
//                animator.Play("Pac_Idle_Up");
//            }

//            else if (lastDir == "Down")
//            {
//                rb.position = rb.position + new Vector2(0, 0.2f);
//                //Debug.Log("Flyttat");
//                animator.Play("Pac_Idle_Down");
//            }
//        }

//        if (collision.gameObject.name.StartsWith("Right"))
//        {
//            rb.position = new Vector2(-52.7f, 4f);
//        }

//        else if (collision.gameObject.name.StartsWith("Left"))
//        {
//            rb.position = new Vector2(52.8f, 3.6f);
//        }
//    }
//}