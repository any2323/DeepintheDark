using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class parallex : MonoBehaviour
{
    Transform cam;
    Vector3 camStartPos;
    float distanceX;
    float distanceY;
    Transform PlayerPos;

    GameObject[] backgrounds;
    Material[] mat;

    [SerializeField]
    float[] backSpeed;

    float farthestBack;

    [Range(0.051f, 0.1f)]
    public float parallaxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        PlayerPos = GameObject.Find("Player").transform;
        camStartPos = cam.position;

        int backCount = transform.childCount;
        mat = new Material[backCount];
        backSpeed = new float[backCount];
        backgrounds = new GameObject[backCount];

        for (int i = 0; i < backCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            mat[i] = backgrounds[i].GetComponent<Renderer>().material;
        }

        BackSpeedCalculate(backCount);
    }

    void BackSpeedCalculate(int backCount)
    {
        for (int i = 0; i < backCount; i++)
        {
            if ((backgrounds[i].transform.position.z - cam.position.z) > farthestBack)
            {
                farthestBack = backgrounds[i].transform.position.z - cam.position.z;
            }
        }

        for (int i = 0; i < backCount; i++)
        {
            backSpeed[i] = 1 - (backgrounds[i].transform.position.z - cam.position.z) / farthestBack;
        }
    }

    private void Update()
    {
        distanceX = cam.position.x - camStartPos.x;
        distanceY = cam.position.y - camStartPos.y;

        for (int i = 0; i < backgrounds.Length; i++)
        {
            float speed = backSpeed[i] * parallaxSpeed;
            if (backgrounds[i].GetComponent<BackGroundBool>().distanceY == false)
            {
                mat[i].SetTextureOffset("_MainTex", new Vector2(distanceX, 0) * speed);
                transform.position = new Vector3(cam.position.x, transform.position.y, transform.position.z);
            }
            else
            {
                mat[i].SetTextureOffset("_MainTex", new Vector2(distanceX, distanceY) * speed);
                transform.position = new Vector3(cam.position.x, cam.position.y, transform.position.z);
            }
        }
    }
}
