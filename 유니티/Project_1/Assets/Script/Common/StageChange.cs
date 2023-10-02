using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageChange : MonoBehaviour
{
    [SerializeField] Animator transtionAnim;
    public void NextStage()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        transtionAnim.SetTrigger("End");
        yield return new WaitForSeconds(0.05f);
        for (int i = 0; i < 9; i++)
        {
            if (SceneManager.GetActiveScene().name == "Stage-" + i)
            {
                SceneManager.LoadScene("Stage-" + (i + 1));
                break;
            }
            else if (SceneManager.GetActiveScene().name == "Stage-9")
            {
                SceneManager.LoadScene("Test-EndStage");
                break;
            }
            else if (SceneManager.GetActiveScene().name == "Test-EndStage")
            {
                SceneManager.LoadScene("Test_FirstScreen");
                break;
            }
        }
        transtionAnim.SetTrigger("Start");
    }


}
