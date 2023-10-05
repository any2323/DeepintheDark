using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAni : MonoBehaviour
{
    public Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Box")
        {
            ani.SetBool("Push", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Box")
        {
            ani.SetBool("Push", false);
        }
    }
}