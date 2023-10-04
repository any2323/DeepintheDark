using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Player player;
    bool lava = false;
    bool life = false;
    GameObject Life_1;
    GameObject Life_2;
    GameObject Life_3;
    Vector3 pos;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        pos = transform.position;

        if (GameObject.Find("Lava"))
        {
            lava = true;
        }

        if (GameObject.Find("Life-1"))
        {
            life = true;
            Life_1 = GameObject.Find("Life-1");
            Life_2 = GameObject.Find("Life-2");
            Life_3 = GameObject.Find("Life-3");
        }
    }

    private void Update()
    {
        Vector3 dirpos = pos;
        dirpos.y = pos.y + 0.08f*  Mathf.Sin(Time.time* 5f);
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
                LavaSpeed.Speed = 3.5f;
            }

            if(life && transform.name == "Item_Heal")
            {
                if (!Life_3.activeSelf && Life_2.activeSelf && Life_1.activeSelf)
                {
                    Life_3.SetActive(true);
                }
                else if (!Life_3.activeSelf && !Life_2.activeSelf && Life_1.activeSelf)
                {
                    Life_2.SetActive(true);
                }
            }

            Destroy(gameObject);
        }
    }
}
