using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] BackgroundAudio;
    public static AudioManager audioManager;
    AudioSource[] Audios;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        audioManager = this;
        Audios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        int Volume = PlayerPrefs.GetInt("SoundOn");
        if(Volume==0)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = PlayerPrefs.GetFloat("GameVolume");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StopAudio()
    {
        foreach(var A in Audios)
        {
            A.Stop();
        }
    }
    public AudioSource[] audios()
    {
        return Audios;
    }
}