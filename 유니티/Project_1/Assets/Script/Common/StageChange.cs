using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageChange : MonoBehaviour
{
    public void NextStage()
    {
        for (int i = 0; i < 9; i++)
        {
            if (SceneManager.GetActiveScene().name == "Stage-" + i)
            {
                SceneManager.LoadScene("Stage-" + (i + 1));
                break;
            }else if(SceneManager.GetActiveScene().name == "Stage-9")
            {
                SceneManager.LoadScene("Test-EndStage");
                break;
            }else if(SceneManager.GetActiveScene().name == "Test-EndStage")
            {
                SceneManager.LoadScene("Test_FirstScreen");
                break;
            }
        }
    }


}
