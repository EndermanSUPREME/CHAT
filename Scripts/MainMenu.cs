using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private int[] ScreenWidth = {800, 1024, 1152, 1280, 1280, 1440, 1600, 1980, 2560}; // [0, 8]
    private int[] ScreenHeight = {600, 768, 864, 720, 1024, 900, 1200, 1080, 1440};


    [SerializeField] GameObject MainMenuObject, SettingScreen, How2PlayScreen, GameScreen, MenuUIObject;
    [SerializeField] Slider MusicSlider, SfxSlider, ResolutionSlider;
    private float musicVolume, sfxVolume, ResolutionIndex, MusicChoice;
    [SerializeField] AudioSource[] GameMusicSelection, SoundEffects;
    [SerializeField] AudioSource CurrentGameMusic;
    [SerializeField] Text MusicDisplay, SFX_Display, ResolutionDisplay;

    // Start is called before the first frame update
    void Start()
    {
        Back2Main();

        MusicSlider.value = 3;
        SfxSlider.value = 3;

        ResolutionIndex = 0;
        MusicChoice = 0;

        // Screen.SetResolution(PlayerPrefs.GetFloat("Width"), PlayerPrefs.GetFloat("Height"), true);
    }

    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = 60;

        ResolutionSettings();
        AudioSettings();
        ChangeDisplay();
    }

    private void ResolutionSettings()
    {
        ResolutionIndex = ResolutionSlider.value;
        Screen.SetResolution(ScreenWidth[(int)ResolutionIndex], ScreenHeight[(int)ResolutionIndex], true);

        PlayerPrefs.SetInt("Width", ScreenWidth[(int)ResolutionIndex]);
        PlayerPrefs.SetInt("Height", ScreenHeight[(int)ResolutionIndex]);
    }

    private void AudioSettings()
    {
        musicVolume = MusicSlider.value / 10;
        sfxVolume = SfxSlider.value / 10;

        PlayerPrefs.SetFloat("MusicVol", musicVolume);
        PlayerPrefs.SetFloat("SFXVol", sfxVolume);

        PlayerPrefs.SetFloat("MusicSlideVal", MusicSlider.value);
        PlayerPrefs.SetFloat("SFXSlideVal", SfxSlider.value);

        if (CurrentGameMusic != null)
        {
            CurrentGameMusic.volume = musicVolume;
        }

        if (SoundEffects != null)
        {
            for (int i = 0; i < SoundEffects.Length; i++)
            {
                SoundEffects[i].volume = sfxVolume;
            }
        }
    }

    private void ChangeOfMusic()
    {
        if (MusicChoice < GameMusicSelection.Length)
        {
            MusicChoice++;
        } else
            {
                MusicChoice = 0;
            }
        
        if (GameMusicSelection != null)
        {
            CurrentGameMusic = GameMusicSelection[(int)MusicChoice];
        }

        PlayerPrefs.SetFloat("GameMusicChoice", MusicChoice);
    }

    private void ChangeDisplay()
    {
        MusicDisplay.text = MusicSlider.value * 10 + " %";
        SFX_Display.text = SfxSlider.value * 10 + " %";
        ResolutionDisplay.text = ScreenWidth[(int)ResolutionIndex] + "x" + ScreenHeight[(int)ResolutionIndex];
    }

    //============= Buttons ================

    public void StartGame()
    {
        MainMenuObject.SetActive(false);
        SettingScreen.SetActive(false);
        How2PlayScreen.SetActive(false);
        GameScreen.SetActive(true);
        MenuUIObject.SetActive(false);
    }

    public void GameSettings()
    {
        MainMenuObject.SetActive(false);
        SettingScreen.SetActive(true);
        How2PlayScreen.SetActive(false);
        GameScreen.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void How2Play()
    {
        MainMenuObject.SetActive(false);
        SettingScreen.SetActive(false);
        How2PlayScreen.SetActive(true);
        GameScreen.SetActive(false);
    }

    public void Back2Main()
    {
        MainMenuObject.SetActive(true);
        SettingScreen.SetActive(false);
        How2PlayScreen.SetActive(false);
        GameScreen.SetActive(false);
    }
}//EndScript