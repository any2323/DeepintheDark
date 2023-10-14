using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Exit : MonoBehaviour
{
    public GameObject exit;
    GameObject EndImage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (SceneManager.GetActiveScene().name == "End")
            {
                GameObject.Find("KeyDownUI").GetComponent<KeyUI>().enabled = false;
                Time.timeScale = 0;
                EndImage = transform.GetChild(0).gameObject;
                EndImage.SetActive(true);
            }
            else
            {
                exit.GetComponent<StageChange>().NextStage();
            }

            for(int i = 0; i < 9; i++)
            {
                if(SceneManager.GetActiveScene().name == "Stage-" + i)
                {
                    UnlockNewLevel();
                    break;
                }
            }
        }
    }


    void UnlockNewLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }

    public void OnClickMain()
    {
        Time.timeScale = 1;
        exit.GetComponent<StageChange>().NextStage();
    }

    public void OnClickGameExit()
    {
        Application.Quit();
    }
}
