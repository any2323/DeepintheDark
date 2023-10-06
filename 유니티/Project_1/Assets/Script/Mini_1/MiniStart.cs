using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniStart : MonoBehaviour
{
    public GameObject miniUI;
    public GameObject miniGame;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        miniUI.SetActive(true);
        miniGame.SetActive(true);
        transform.gameObject.SetActive(false);
    }
}
