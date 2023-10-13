using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointControl : MonoBehaviour
{
    GameObject Player;
    GameObject director;
    Vector2 FloorY;
    public int minSpeed = 10;
    public int maxSpeed = 100;

    void Start()
    {
        this.Player = GameObject.Find("Player");
        director = GameObject.Find("GameDirector");
        FloorY = GameObject.Find("PointGenerator").GetComponent<FallingPoint>().FloorPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;

        int radSpeed = Random.Range(minSpeed, maxSpeed);

        if (SceneManager.GetActiveScene().name == "Stage-9")
        {
            transform.Translate(0, -1 * (radSpeed * Time.deltaTime * 0.8f), 0);
        }
        else
        {
            transform.Translate(0, -1 * (radSpeed * Time.deltaTime * 0.4f), 0); //랜덤 주어지면 된다.
        }

        if (transform.position.y < FloorY.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            if (gameObject.name == "Point1(Clone)")
            {
                director.GetComponent<FallingPoint_GameDirector>().Up_Point();
            }
            else if (gameObject.name == "Point2(Clone)")
            {
                director.GetComponent<FallingPoint_GameDirector>().UpUp_Point();
            }
            else if (gameObject.name == "Rockfall_1(Clone)")
            {
                director.GetComponent<FallingPoint_GameDirector>().Down_Point();
                director.GetComponent<FallingPoint_GameDirector>().Down_Point();
            }
            else if (gameObject.name == "Rockfall_2(Clone)" || gameObject.name == "Rockfall_3(Clone)")
            {
                director.GetComponent<FallingPoint_GameDirector>().Down_Point();
            }
            else if (gameObject.name == "Item_Heal(Clone)")
            {
                director.GetComponent<FallingPoint_GameDirector>().Heal();
            }
            Destroy(gameObject);
        }
    }
}
