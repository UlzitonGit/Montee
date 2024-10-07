using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioSource Music;
    [SerializeField] private AudioSource SFX;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] GameObject optionsPanel;
    bool panelActive = false;
    float musicVolume;
    float sfxVolume;
    
    private bool _isFirstTime = true;
    void Start()
    {
        musicVolume = PlayerPrefs.GetFloat("musicVolume");
        sfxVolume = PlayerPrefs.GetFloat("sfxVolume");

        if (_isFirstTime)
        {
            musicSlider.value = 1f;
            SFXSlider.value = 1f;
            
            _isFirstTime = false;
        }
        else
        {
            musicSlider.value = musicVolume;
            SFXSlider.value = sfxVolume;
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && panelActive == false)
        {
            optionsPanel.SetActive(true);
            Time.timeScale = 0;
            panelActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) && panelActive == true)
        {
            optionsPanel.SetActive(false);
            Time.timeScale = 1;
            panelActive = false;
            Sett();
        }
    }
    public void Sett()
    {
        musicVolume = musicSlider.value;
        sfxVolume = SFXSlider.value;
        Music.volume = musicVolume;
        SFX.volume = sfxVolume;
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
    }
  
}
