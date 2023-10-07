using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public GameObject Lava;
    public Camera cameraSize;
    public bool camerAni = false;
    void Start()
    {
        cameraSize = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        if (camerAni)
        {
            cameraSize.orthographicSize += (0.5f * Time.deltaTime);
            if(cameraSize.orthographicSize >= 6.8)
            {
                camerAni = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Lava.SetActive(true);
        camerAni = true;
    }
}
