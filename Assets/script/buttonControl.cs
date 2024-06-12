using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonControl : MonoBehaviour
{
    public Button spin,stop;
    public Button autoSpin;
    public Button home,plus,incre;
    public AudioSource[] Musics;
    public Sprite[] sprites = new Sprite[2];
    public Image Images;
    public bool IsOn = true;
    private const string SoundKey = "SoundValue";
    public static buttonControl music;

    public void Awake()
    {
        music = this;
    }

    void Start()
    {

        LoadSoundValue(); // Load the sound value when the game starts
    }

    public void SFXSound()
    {
        IsOn = !IsOn;
        if (IsOn)
        {
            Images.sprite = sprites[0];
            Images.sprite = sprites[0];
            SetMuteState(false);
        }
        else
        {
            Images.sprite = sprites[1];
            Images.sprite = sprites[1];
            SetMuteState(true);
        }

        SaveSoundValue(); // Save the sound value when the button is clicked
    }

    void SetMuteState(bool isMuted)
    {
        foreach (var music in Musics)
        {
            music.mute = isMuted;
        }
    }

    void SaveSoundValue()
    {
        // Save the sound value
        PlayerPrefs.SetInt(SoundKey, IsOn ? 1 : 0);
    }

    void LoadSoundValue()
    {
        // Load the sound value and set the state accordingly
        if (PlayerPrefs.HasKey(SoundKey))
        {
            int savedValue = PlayerPrefs.GetInt(SoundKey);
            IsOn = savedValue == 1;
            SetMuteState(!IsOn);
            Images.sprite = IsOn ? sprites[0] : sprites[1];
            Images.sprite = IsOn ? sprites[0] : sprites[1];
        }
    }

    public void btnSpin()
    {
        FindAnyObjectByType<AppControl>().closBox();
        FindAnyObjectByType<AppControl>().isStart = true;
        spin.GetComponent<Button>().enabled = false;
        spin.GetComponent<Button>().image.color = Color.gray;      
        home.GetComponent<Button>().enabled = false;
        home.GetComponent<Button>().image.color = Color.gray;
        autoSpin.GetComponent<Button>().enabled = false;
        autoSpin.GetComponent<Button>().image.color = Color.gray;
        plus.GetComponent<Button>().enabled = false;
        plus.GetComponent<Button>().image.color = Color.gray;
        incre.GetComponent<Button>().enabled = false;
        incre.GetComponent<Button>().image.color = Color.gray;
    }

    public void btnAutoSpin()
    {
        FindAnyObjectByType<AppControl>().closBox();
        FindAnyObjectByType<AppControl>().isAuto = true;
        FindAnyObjectByType<AppControl>().isStop = true;
        spin.GetComponent<Button>().enabled = false;
        spin.GetComponent<Button>().image.color = Color.gray;
        stop.GetComponent<Button>().enabled = true;
        stop.GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
        plus.GetComponent<Button>().enabled = false;
        plus.GetComponent<Button>().image.color = Color.gray;
        incre.GetComponent<Button>().enabled = false;
        incre.GetComponent<Button>().image.color = Color.gray;
        FindAnyObjectByType<AppControl>().btnAuto[0].SetActive(false);
        FindAnyObjectByType<AppControl>().btnAuto[1].SetActive(true);
    }

    public void btnStop()
    {
        FindAnyObjectByType<AppControl>().isStop = false;
        stop.GetComponent<Button>().enabled = false;
        stop.GetComponent<Button>().image.color = Color.gray;
        
    }

    public void btnStart()
    {
        FindAnyObjectByType<AppControl>().panel[0].SetActive(false);
        FindAnyObjectByType<AppControl>().panel[1].SetActive(true);
    }
    public void btnHome()
    {
        FindAnyObjectByType<AppControl>().panel[1].SetActive(false);
        FindAnyObjectByType<AppControl>().panel[0].SetActive(true);
        FindAnyObjectByType<DBpoint>().dataGame();
    }
    public void btnTip()
    {
        FindAnyObjectByType<AppControl>().panel[2].SetActive(true);

    }
    public void btnBack()
    {
        FindAnyObjectByType<AppControl>().panel[2].SetActive(false);

    }
    public void btnExit()
    {
        Application.Quit();
    }
    public void btnPlus()
    {
        FindAnyObjectByType<AppControl>().plusVal();
    }
    public void btnIncreap()
    {
        FindAnyObjectByType<AppControl>().Increap();

    }
}
