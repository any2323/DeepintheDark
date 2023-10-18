using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Player player;
    bool lava = false;
    Vector3 pos;
    public GameObject Lava;
    GameObject Open;
    GameObject Close;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        pos = transform.position;

        if (transform.name == "Item_Treasure")
        {
            Open = GameObject.Find("Item_Treasure_Open");
            Close = GameObject.Find("Item_Treasure_Close"); ;
            Open.SetActive(false);
        }
        
        if (transform.name == "Item_Key")
        {
            Open = GameObject.Find("EndPoint1_Open");
            Close = GameObject.Find("EndPoint1_Close");
            Open.SetActive(false);
        }
        
    }

    private void Update()
    {
        if (GameObject.Find("Lava") && lava == false)
        {
            lava = true;
        }

        Vector3 dirpos = pos;
        dirpos.y = pos.y + 0.08f * Mathf.Sin(Time.time * 5f);
        transform.position = dirpos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "Player")
        {
            if(transform.name == "Item_DoubleJump") {
                player.DoubleJump = true;
                Destroy(gameObject);
            }

            if (transform.name == "Item_JumpHeight")
            {
                player.jumpHeight = 2.5f;
                player.timeToJumpApex = 0.25f;
                Destroy(gameObject);
            }

            if (lava && transform.name == "Item_Lava")
            {
                risingLava LavaSpeed = Lava.GetComponent<risingLava>();
                LavaSpeed.Speed += 1f;
                Destroy(gameObject);
            }

            if (transform.name == "Item_Treasure")
            {
                transform.GetComponent<BoxCollider2D>().enabled = false;
                Open.SetActive(true);
                Close.SetActive(false);
            }

            if(transform.name == "Item_Key")
            {
                if (!Open.activeSelf)
                {
                    Open.SetActive(true);
                    Close.SetActive(false);
                    Destroy(gameObject);
                }
            }

            if(transform.name == "Item_Smile")
            {
                return;
            }

            if(transform.name == "Item_Computer")
            {
                return;
            }
        }
    }


}
