using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    [SerializeField]
    private ButtonFlag Flag;
    public GameObject GrayBase;
    public GameObject GamePause;
    public GameObject Setting;
    public GameObject Pause;
    public GameObject _Exit;
    public GameObject Refresh;
    AudioSource source;

    private void Start()
    {
        source = GameObject.Find("MusicSource").GetComponent<AudioSource>();
    }
    public void OnPauseButton()
    {
        Button RefreshButton = GameObject.Find("RefreshButton").GetComponent<Button>();

        if (!Flag.GamePauseFlag)
        {
            GrayBase.SetActive(true);
            Flag.GamePauseFlag = true;
            GamePause.SetActive(Flag.GamePauseFlag);
            RefreshButton.interactable = false;
            Time.timeScale = 0;
        }
        else
        {
            GrayBase.SetActive(false);
            Flag.Flag_Init();
            GamePause.SetActive(Flag.GamePauseFlag);
            Pause.SetActive(Flag.PauseFlag);
            Setting.SetActive(Flag.SettingFlag);
            _Exit.SetActive(Flag.ExitFlag);
            RefreshButton.interactable = true;
            Time.timeScale = 1;
        }
    }

    public void OnSettingButton()
    {
        if (!Flag.SettingFlag)
        {
            Flag.PauseFlag = false;
            Pause.SetActive(Flag.PauseFlag);
            Flag.SettingFlag = true;
            Setting.SetActive(Flag.SettingFlag);
        }
        else
        {
            Flag.PauseFlag = true;
            Pause.SetActive(Flag.PauseFlag);
            Flag.SettingFlag = false;
            Setting.SetActive(Flag.SettingFlag);
        }
    }

    public void OnExitButton()
    {
        Button settingButton= GameObject.Find("SettingButton").GetComponent<Button>();
        Button exitButton = GameObject.Find("ExitButton").GetComponent<Button>();

        if (!Flag.ExitFlag)
        {
            Flag.ExitFlag = true;
            _Exit.SetActive(Flag.ExitFlag);
            settingButton.interactable = false;
            exitButton.interactable = false;
        }
        else
        {
            Flag.ExitFlag = false;
            _Exit.SetActive(Flag.ExitFlag);
            settingButton.interactable = true;
            exitButton.interactable = true;
        }
    }

    public void OnRefreshButton()
    {
        Button PauseButton = GameObject.Find("PauseButton").GetComponent<Button>();

        if (!Flag.RefreshFlag)
        {
            GrayBase.SetActive(true);
            Flag.RefreshFlag = true;
            Refresh.SetActive(Flag.RefreshFlag);
            PauseButton.interactable = false;
            Time.timeScale = 0;
        }
        else
        {
            GrayBase.SetActive(false);
            Flag.RefreshFlag = false;
            Refresh.SetActive(Flag.RefreshFlag);
            PauseButton.interactable = true;
            Time.timeScale = 1;
        }
    }

    public void OnExit_Yes_Button()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
        source.clip = Resources.Load<AudioClip>("Main");
        source.Play();
    }

    public void OnRefresh_Yes_Button()
    {
        if (Flag.RefreshFlag)
        {
            Flag.RefreshFlag = false;
            Refresh.SetActive(Flag.RefreshFlag);
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
