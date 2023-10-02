using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StageMenu : MonoBehaviour
{
    public Button[] buttons;
    public GameObject stageButtons;
    [SerializeField] Animator transtionAnim;
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
        StartCoroutine(ChangAni(stageName));
    }

    IEnumerator ChangAni(string stageName)
    {
        transtionAnim.SetTrigger("End");
        yield return new WaitForSeconds(0.05f);
        SceneManager.LoadScene(stageName);
        transtionAnim.SetTrigger("Start");
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
