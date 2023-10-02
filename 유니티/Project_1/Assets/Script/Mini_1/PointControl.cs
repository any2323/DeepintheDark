using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointControl : MonoBehaviour
{
    GameObject Player;
    GameObject director;
    public int minSpeed = 10;
    public int maxSpeed = 100;

    void Start()
    {
        this.Player = GameObject.Find("Player");
        director = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;

        int radSpeed = Random.Range(minSpeed, maxSpeed);
        
        transform.Translate(0, -1 * (radSpeed * 0.0005f), 0); //랜덤 주어지면 된다.

        if (transform.position.y < -14f)
        {
            Destroy(gameObject);
        }

        Vector2 p1 = transform.position;
        Vector2 p2 = this.Player.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;

        if (d < 1f)
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
