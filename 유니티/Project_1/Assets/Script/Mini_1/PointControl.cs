using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointControl : MonoBehaviour
{
    GameObject Player;
    GameObject director;
     int minSpeed = 5;
     int maxSpeed = 45;

    void Start()
    {
        this.Player = GameObject.Find("Player");
        director = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        int rad = Random.Range(minSpeed, maxSpeed);
        
        transform.Translate(0, -1 * (rad * 0.001f), 0); //랜덤 주어지면 된다.

        if (transform.position.y < -14f)
        {
            Destroy(gameObject);
        }

        Vector2 p1 = transform.position;
        Vector2 p2 = this.Player.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;

        if (d < 1.5f)
        {
            if (gameObject.name == "Plus(Clone)")
            {
                director.GetComponent<FallingPoint_GameDirector>().Up_Point();
            }else if(gameObject.name == "Minus(Clone)")
            {
                director.GetComponent<FallingPoint_GameDirector>().Down_Point();
            }
            Destroy(gameObject);
        }
    }


}
