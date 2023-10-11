using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;


public class SliderUI : MonoBehaviour, IPointerClickHandler
{ 
    public Slider slider;
    public GameObject MusicSource;
    private AudioMixer mixer;
    public GameObject SpeakerON;
    public GameObject SpeakerOff;

    void Awake()
    {
        mixer = Resources.Load<AudioMixer>("GameSound");
        MusicSource = GameObject.Find("MusicSource");
        slider.value = PlayerPrefs.GetFloat("Master", 0.75f);
    }

    void Start()
    {
       if(slider.value < 0.1)
        {
            SpeakerON.SetActive(false);
            SpeakerOff.SetActive(true);
        }
        else
        {
            SpeakerON.SetActive(true);
            SpeakerOff.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        eventData.Use();
    }

    public void SetLevel(float sliderValue)
    {
        if(sliderValue == 0)
        {
            mixer.SetFloat("Master", -80f);
            SpeakerON.SetActive(false);
            SpeakerOff.SetActive(true);
        }
        else
        {
            mixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20);
            PlayerPrefs.SetFloat("Master", sliderValue);
            SpeakerON.SetActive(true);
            SpeakerOff.SetActive(false);
        }
    }
}