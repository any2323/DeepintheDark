using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingPoint : MonoBehaviour
{
    public GameObject Point1;
    public GameObject Point2;
    public GameObject Item;
    public GameObject Rock1;
    public GameObject Rock2;
    public GameObject Rock3;
    public Vector2 RightPoint;
    public Vector2 LeftPoint;
    public Vector2 FloorPoint;
    public float span = 0.2f;
    float time = 0;

    private void Start()
    {
        FloorPoint.x = RightPoint.x;;
    }
    void Update()
    {
        if (Time.timeScale == 0)
            return;

        this.time += Time.deltaTime;
        if (this.time > this.span)
        {
            this.time = 0;
            GameObject Point = Instantiate(RandomPoint());
            float point = Random.Range(RightPoint.x, LeftPoint.x);

            Point.transform.position = new Vector3(point, RightPoint.y, 0);
        }
    }

    GameObject RandomPoint()
    {

        if (SceneManager.GetActiveScene().name == "Stage-9")
        {
            int random = Random.Range(0, 11);
            switch (random)
            {
                case 0:
                    return Rock1;
                case 1:
                    return Rock2;
                case 2:
                    return Rock3;
                case 3:
                case 4:
                    return Item;
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    return Rock1;
            }
        }
        else
        {
            int random = Random.Range(0, 14);
            switch (random)
            {
                case 0:
                    return Rock1;
                case 1:
                    return Rock2;
                case 2:
                    return Rock3;
                case 3:
                    return Point2;
                case 4:
                    return Item;
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                    return Point1;
            }
        }
        return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(LeftPoint, RightPoint);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector3(LeftPoint.x, FloorPoint.y, 0), new Vector3(RightPoint.x, FloorPoint.y, 0));
    }
}
