using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    [SerializeField]
    private ButtonFlag Flag;
    public GameObject GamePause;
    public GameObject Setting;
    public GameObject Pause;
    public GameObject _Exit;
    public GameObject Refresh;

    public void OnPauseButton()
    {
        if (!Flag.GamePauseFlag)
        {
            Flag.GamePauseFlag = true;
            GamePause.SetActive(Flag.GamePauseFlag);
            Time.timeScale = 0;
        }
        else
        {
            Flag.Flag_Init();
            GamePause.SetActive(Flag.GamePauseFlag);
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
        if (!Flag.ExitFlag)
        {
            Flag.ExitFlag = true;
            _Exit.SetActive(Flag.ExitFlag);
        }
        else
        {
            Flag.ExitFlag = false;
            _Exit.SetActive(Flag.ExitFlag);
        }
    }

    public void OnRefreshButton()
    {
        if(!Flag.RefreshFlag)
        {
            Flag.RefreshFlag = true;
            Refresh.SetActive(Flag.RefreshFlag);

        }
        else
        {
            Flag.RefreshFlag = false;
            Refresh.SetActive(Flag.RefreshFlag);
        }
    }

    public void OnExit_Yes_Button()
    {
        print("나갔습니다.");
    }

    public void OnRefresh_Yes_Button()
    {
        print("새로고침");
        if (Flag.RefreshFlag)
        {
            Flag.RefreshFlag = false;
            Refresh.SetActive(Flag.RefreshFlag);
        }
    }
}
