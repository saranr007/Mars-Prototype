using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControls : MonoBehaviour
{
    public Transform SoundOn;
    public Transform SoundOff;
    public Slider VolumeSlider;
    float volume=1f;
    public RectTransform Options;
    bool SoundButton = false;
    bool optionsdisplay=false;
    [HideInInspector]public bool isPaused=false;
    bool IsSoundOff;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayerPrefs.SetFloat("GameVolume", 1);
            PlayerPrefs.SetInt("SoundOn", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsSoundOff)
        {
            AudioListener.volume = VolumeSlider.value;
            volume = VolumeSlider.value;
        }
        PlayerPrefs.SetFloat("GameVolume", volume);
        
    }
    public void GoToGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    
    public void Sound_ON_OFF()
    {
        if (!SoundButton)
        {
            PlayerPrefs.SetInt("SoundOn", 0);
            AudioListener.volume = 0;
            SoundOff.gameObject.SetActive(true);
            SoundOn.gameObject.SetActive(false);
            IsSoundOff = true;
        }
        else
        {
            AudioListener.volume = volume;
            SoundOn.gameObject.SetActive(true);
            SoundOff.gameObject.SetActive(false);
            PlayerPrefs.SetInt("SoundOn", 1);
            IsSoundOff = false;
        }
        SoundButton = !SoundButton;
    }
    public void Pause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f;         
        }
        else {
            Time.timeScale = 1;
        }
        isPaused = !isPaused;
        Debug.LogWarning("puse" + isPaused);
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    private void OnEnable()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            AudioListener.volume = PlayerPrefs.GetFloat("GameVolume");
        }
    }
}
