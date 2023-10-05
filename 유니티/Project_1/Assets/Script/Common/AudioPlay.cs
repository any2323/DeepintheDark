using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlay : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer mixer;
    public AudioSource source;
    public float savedVolume;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        savedVolume = PlayerPrefs.GetFloat("Master", 0.75f);
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Start()
    {
        if (savedVolume == 0)
        {
            source.mute = true;
        }
        else
        {
            if(source.mute == true)
            {
                source.mute = false;
            }
            mixer.SetFloat("Master", Mathf.Log10(savedVolume) * 20);
        }
    }
}
