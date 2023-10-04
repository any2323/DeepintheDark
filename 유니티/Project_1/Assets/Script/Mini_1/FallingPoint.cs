using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPoint : MonoBehaviour
{
    public GameObject Point;
    public GameObject Rock1;
    public GameObject Rock2;
    public GameObject Rock3;
    public Vector2 RightPoint;
    public Vector2 LeftPoint;
    public float span = 0.2f;
    float time = 0;

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
        int random = Random.Range(0, 10);
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
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                return Point;
        }
        return Point;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(LeftPoint, RightPoint);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector3(LeftPoint.x, -14f, 0), new Vector3(RightPoint.x, -14f, 0));
    }
}
