using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioPlay : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer mixer;
    public AudioSource source;
    public float savedVolume;
    private GameObject[] musics;

    private void Awake()
    {
        musics = GameObject.FindGameObjectsWithTag("Music");

        if(musics.Length >= 2)
        {
            Destroy(this.gameObject);
        }

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
