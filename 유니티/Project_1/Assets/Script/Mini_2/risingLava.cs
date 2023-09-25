using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class risingLava : MonoBehaviour
{
    public int Speed = 1;
    void Update()
    {
        transform.Translate(0, (0.001f*Speed), 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            print("End");
        }
    }
}
