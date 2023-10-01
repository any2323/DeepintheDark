using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Player player;
    bool lava = false;

    void Start()
    {
         player = GameObject.Find("Player").GetComponent<Player>();

        if (GameObject.Find("Lava"))
        {
            lava = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "Player")
        {
            if(transform.name == "Item_DoubleJump") {
                player.DoubleJump = true;
            }

            if(transform.name == "Item_JumpHeight")
            {
                player.jumpHeight = 2.5f;
                player.timeToJumpApex = 0.25f;
            }

            if(lava && transform.name == "Item_Lava")
            {
                risingLava LavaSpeed = GameObject.Find("Lava").GetComponent<risingLava>();
                LavaSpeed.Speed = 3.5f;
            }
            Destroy(gameObject);
        }
    }
}
