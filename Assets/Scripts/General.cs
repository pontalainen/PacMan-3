using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class General : MonoBehaviour
{
    [SerializeField]
    public GameObject dotSmallPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (float x = -50; x < 53; x += 4)
        {
            for (float y = -56; y < 57; y += 4)
            {
                Instantiate(dotSmallPrefab, new Vector2(x, y), Quaternion.identity);
            }
        }
    }
}
