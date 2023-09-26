using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    public GameObject Lava;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Lava.SetActive(true);
    }
}
