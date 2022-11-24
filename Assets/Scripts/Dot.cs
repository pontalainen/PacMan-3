using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        
        if (collision.gameObject.name.StartsWith("Pac")
            && collision.gameObject.tag != "WallCheck")
        {
            Debug.Log(collision.gameObject.tag);
            Destroy(this.gameObject);
        }
    }
}
