using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class risingLava : MonoBehaviour
{
    public float Speed = 1;
    void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }
        transform.Translate(0, Speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
