using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFlag : MonoBehaviour
{
    public bool GamePauseFlag = false;
    public bool PauseFlag = true;
    public bool SettingFlag = false;
    public bool ExitFlag = false;
    public bool RefreshFlag = false;

    void Start()
    {
        Flag_Init();
    }

    public void Flag_Init()
    {
        GamePauseFlag = false;
        PauseFlag = true;
        SettingFlag = false;
        ExitFlag = false;
        RefreshFlag = false;
    }
}