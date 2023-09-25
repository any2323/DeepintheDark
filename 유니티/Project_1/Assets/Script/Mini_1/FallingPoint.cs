using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPoint : MonoBehaviour
{
    public GameObject Plus;
    public GameObject Minus;
    public Vector2 RightPoint;
    public Vector2 LeftPoint;
    float span = 0.5f;
    float time = 0;

    void Update()
    {
        this.time += Time.deltaTime;
        if(this.time > this.span)
        {
            this.time = 0;
            GameObject Point = Instantiate(RandomPoint());
            float point = Random.Range(RightPoint.x, LeftPoint.x);

            Point.transform.position = new Vector3(point, RightPoint.y, 0);
        }
    }

    GameObject RandomPoint()
    {
        int random = Random.Range(0, 2);
        switch (random)
        {
            case 0:
                return Minus;
            case 1:
                return Plus;
        }
        return Plus;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(LeftPoint, RightPoint);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector3(LeftPoint.x, -14f, 0), new Vector3(RightPoint.x,-14f, 0));
    }


}
