using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour
{
    public bool CrashVar = true;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("maze"))
        {
            CrashVar = true;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("maze"))
        {
            CrashVar = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("maze"))
        {
            CrashVar = false;
        }
    }
}
