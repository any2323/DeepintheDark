using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Player player;
    bool lava = false;
    Vector3 pos;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        pos = transform.position;
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
            }

            if(transform.name == "Item_JumpHeight")
            {
                player.jumpHeight = 2.5f;
                player.timeToJumpApex = 0.25f;
            }

            if(lava && transform.name == "Item_Lava")
            {
                risingLava LavaSpeed = GameObject.Find("Lava").GetComponent<risingLava>();
                LavaSpeed.Speed = 5f;
            }
            
            Destroy(gameObject);
        }
    }


}
