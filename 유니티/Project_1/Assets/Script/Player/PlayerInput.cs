using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent (typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    Player player;
    public Animator ani;
    AudioSource source;
    
    public SpriteRenderer rend;
    void Start()
    {
        source = GameObject.Find("WalkSound").GetComponent<AudioSource>();
        player = GetComponent<Player>();
        ani = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            source.mute = true;
            return;
        }
        else
        {
            source.mute = false;
        }

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

        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            source.Play();
        }else if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                return;
            }
            source.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.OnJumpDown();
            ani.SetTrigger("Jump");
        }
    }
}
