using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class FallingPoint_GameDirector : MonoBehaviour
{
    private int score_data;
    bool EndFlag = false;
    public GameObject EndPoint;
    public GameObject Life_1;
    public GameObject Life_2;
    public GameObject Life_3;
    public TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        score_data = 0;
        score.text = "Score : " + score_data;
    }

    // Update is called once per frame
    public void Up_Point()
    {
        score_data += 10;
        score.text = "Score : " + score_data;
        if (score_data >= 300 && !EndFlag)
        {
            EndFlag = true;
            EndPoint.SetActive(true);
        }
    }

    public void UpUp_Point()
    {
        score_data += 100;
        score.text = "Score : " + score_data;
        if (score_data >= 300 && !EndFlag)
        {
            EndFlag = true;
            EndPoint.SetActive(true);
        }
    }

    public void Down_Point()
    {
        if (Life_3.activeSelf && Life_2.activeSelf && Life_1.activeSelf)
        {
            Life_3.SetActive(false);
            
        }else if(!Life_3.activeSelf && Life_2.activeSelf && Life_1.activeSelf)
        {
            Life_2.SetActive(false);
        }else if(!Life_3.activeSelf && !Life_2.activeSelf && Life_1.activeSelf)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Heal()
    {
        if (!Life_3.activeSelf && Life_2.activeSelf && Life_1.activeSelf)
        {
            Life_3.SetActive(true);
        }
        else if (!Life_3.activeSelf && !Life_2.activeSelf && Life_1.activeSelf)
        {
            Life_2.SetActive(true);
        }
    }
}
