using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyUI : MonoBehaviour
{
    [SerializeField]
    private ButtonFlag Flag;
    public Button Refresh;
    public Button Pause;
    public Button SettingButton;
    public Button ExitButton;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if ((!Flag.GamePauseFlag && !Flag.RefreshFlag) || (Flag.GamePauseFlag && !Flag.RefreshFlag))
            {
                Pause.onClick.Invoke();
                if (SettingButton.interactable.Equals(false))
                {
                    SettingButton.interactable = true;
                    ExitButton.interactable = true;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            if ((!Flag.GamePauseFlag && !Flag.RefreshFlag) || (!Flag.GamePauseFlag && Flag.RefreshFlag))
                Refresh.onClick.Invoke();
        }
        else
        {
            return;
        }
    }
}
