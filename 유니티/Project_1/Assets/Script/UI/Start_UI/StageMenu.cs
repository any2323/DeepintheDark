using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

public class StageMenu : MonoBehaviour
{
    public Button[] buttons;
    public GameObject stageButtons;
    [SerializeField] Animator transtionAnim;
    AudioSource source;
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
    private void Start()
    {
        source = GameObject.Find("MusicSource").GetComponent<AudioSource>();
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
        ChangeSound(stageName);
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

    public void ChangeSound(string stageName)
    {
        if (stageName == "Stage-3" || stageName == "Stage-6" || stageName == "Stage-9")
        {
            source.clip = Resources.Load<AudioClip>("369");
            source.Play();
        }
        else if (stageName == "Stage-4" || stageName == "Stage-5" || stageName == "Stage-7" || stageName == "Stage-8")
        {
            source.clip = Resources.Load<AudioClip>("4578");
            source.Play();
        }
        else // 메인 화면과 엔딩 화면
        {
            source.clip = Resources.Load<AudioClip>("12");
            source.Play();
        }
    }
}
