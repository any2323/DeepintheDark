using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLavaPoint : MonoBehaviour
{
    public GameObject Lava;
    public GameObject Background;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Lava.SetActive(false);
        Destroy(gameObject);
    }
}
