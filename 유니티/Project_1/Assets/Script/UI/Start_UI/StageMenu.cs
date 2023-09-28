using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StageMenu : MonoBehaviour
{
    public Button[] buttons;
    public GameObject stageButtons;
    private void Awake()
    {
        ButtonsToAraay();
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for(int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }
    public void OpenStage(int StageId)
    {
        string stageName = "Stage-" + StageId;
        SceneManager.LoadScene(stageName);
    }

    void ButtonsToAraay()
    {
        int childCount = stageButtons.transform.childCount;
        buttons = new Button[childCount];
        for(int i = 0; i < childCount; i++)
        {
            buttons[i] = stageButtons.transform.GetChild(i).gameObject.GetComponent<Button>();
        }
    }
}
