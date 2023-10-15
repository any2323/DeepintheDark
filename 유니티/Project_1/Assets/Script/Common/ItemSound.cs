using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSound : MonoBehaviour
{
    AudioSource source;
    AudioClip ItemClip;
    AudioClip DeBuffItem;
    public void Start()
    {
        source = GetComponent<AudioSource>();
        ItemClip = Resources.Load<AudioClip>("Item");
        DeBuffItem = Resources.Load<AudioClip>("Debuff");
    }

    public void Update()
    {
        if(Time.timeScale == 0)
        {
            source.mute = true;
        }
        else
        {
            source.mute = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.transform.tag == "Box") {
            source.Play();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.transform.tag == "Box")
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    source.Play();
                }
            }
            else
            {
                source.Stop();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.transform.tag == "Box")
        {
            source.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Item")
        {
            if (collision.transform.name == "Item_Lava"|| collision.transform.name == "Rockfall_1(Clone)" || collision.transform.name == "Rockfall_2(Clone)" || collision.transform.name == "Rockfall_3(Clone)")
            {
                source.PlayOneShot(DeBuffItem);
            }
            else
            {
                source.PlayOneShot(ItemClip);
            }
        }
    }
}
