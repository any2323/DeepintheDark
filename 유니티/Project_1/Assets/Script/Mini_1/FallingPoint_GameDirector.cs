using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPoint_GameDirector : MonoBehaviour
{
    private int score_data;

    // Start is called before the first frame update
    void Start()
    {
        score_data = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Up_Point()
    {
        score_data += 10;
        print(score_data);
    }

    public void Down_Point()
    {
        score_data -= 5;
        print(score_data);
    }
}
