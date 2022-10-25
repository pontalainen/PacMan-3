using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
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
