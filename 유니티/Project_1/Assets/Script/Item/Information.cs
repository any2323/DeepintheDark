using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information : MonoBehaviour
{
    public GameObject Wood;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.transform.tag == "Player")
        {
            Wood.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.transform.tag == "Player")
        {
            Wood.SetActive(false);
        }
    }
}
