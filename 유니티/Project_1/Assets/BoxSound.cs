using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSound : MonoBehaviour
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.transform.tag == "Box") {
            source.Play();
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
            if (collision.transform.name == "Item_Lava")
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
