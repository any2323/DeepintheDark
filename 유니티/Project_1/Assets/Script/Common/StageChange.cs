using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageChange : MonoBehaviour
{
    [SerializeField] Animator transtionAnim;
    AudioSource source;

    private void Start()
    {
         source = GameObject.Find("MusicSource").GetComponent<AudioSource>();
    }
    public void NextStage()
    {
        ChangeSound();
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
                SceneManager.LoadScene("End");
                break;
            }
            else if (SceneManager.GetActiveScene().name == "End")
            {
                SceneManager.LoadScene("Main");
                break;
            }
        }
        transtionAnim.SetTrigger("Start");
    }

    public void ChangeSound()
    {
        if (SceneManager.GetActiveScene().name == "Stage-2" || SceneManager.GetActiveScene().name == "Stage-5" || SceneManager.GetActiveScene().name == "Stage-8")
        {
            source.clip = Resources.Load<AudioClip>("369");
            source.Play();
        }
        else if (SceneManager.GetActiveScene().name == "Stage-3" || SceneManager.GetActiveScene().name == "Stage-4" || SceneManager.GetActiveScene().name == "Stage-6" || SceneManager.GetActiveScene().name == "Stage-7")
        {
            source.clip = Resources.Load<AudioClip>("4578");
            source.Play();
        }
        else if(SceneManager.GetActiveScene().name == "Stage-9") //엔딩 화면
        {
            source.clip = Resources.Load<AudioClip>("End");
            source.Play();
        }
        else if (SceneManager.GetActiveScene().name == "End") // 메인화면
        {
            source.clip = Resources.Load<AudioClip>("Main");
            source.Play();
        }
    }
}
