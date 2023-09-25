using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    Player player;
    public Animator ani;
    public SpriteRenderer rend;
    void Start()
    {
        player = GetComponent<Player>();
        ani = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player.SetDirectinalInput (directionalInput);


        if (directionalInput.x == 1)
        {
            rend.flipX = false;
        }

        if (directionalInput.x == -1)
        {
            rend.flipX = true;
        }

        if (directionalInput.x == 0)
        {
            ani.SetBool("Walk", false);
            ani.SetBool("Push", false);
        }
        else
        {
            ani.SetBool("Walk", true);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.OnJumpDown();
            ani.SetTrigger("Jump");
        }
    }
}
