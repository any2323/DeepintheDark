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

    void Awake()
    {
        mixer = Resources.Load<AudioMixer>("GameSound");
        MusicSource = GameObject.Find("MusicSource");
        slider.value = PlayerPrefs.GetFloat("Master", 0.75f);
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
        }
        else
        {
            mixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20);
            PlayerPrefs.SetFloat("Master", sliderValue);
        }
    }
}