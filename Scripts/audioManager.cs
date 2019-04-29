using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class audioManager : MonoBehaviour
{

    [HideInInspector] public AudioSource effectsPlayer;
    [HideInInspector] public AudioSource BGMusicPlayer;

    [HideInInspector]public Slider volumeChanger;
    [HideInInspector] public Toggle muteChanger;
    [HideInInspector] public Slider volumeChangerB;
    [HideInInspector] public Toggle muteChangerB;
    //public Text value;

    [Header("Background music editor")]

    public AudioClip[] backgroundMusic;
    public float volumeB;
    public float startVolumeB;
    public float pitchB;
    public float sound2DB;
    public bool muteB;
    public bool loopB;
    [HideInInspector]public Text volumeBG;


    [Header("Soundeffects editor")]
    public AudioClip[] soundEffects;
    public float volume;
    public float startVolume;
    public float pitch;
    public float sound2D;
    public bool mute;
    public bool loop;
    [HideInInspector]public Text volumeE;


    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        loop = false;

        volume = startVolume;
        volumeChanger.value = volume;

        volumeB = startVolumeB;
        volumeChangerB.value = volumeB;
        loopB = true;
        PlayBGMusic(0);

    }


    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            volumeBG.text = "" + Mathf.RoundToInt(volumeChangerB.value * 100);
            volumeE.text = "" + Mathf.RoundToInt(volumeChanger.value * 100);
        }
    }

    public void PlayBGMusic(int backgroundNumber)
    {
        BGMusicPlayer.clip = backgroundMusic[backgroundNumber];
        BGMusicPlayer.volume = volumeB;
        BGMusicPlayer.pitch = pitchB;
        BGMusicPlayer.mute = muteB;
        BGMusicPlayer.loop = loopB;
        BGMusicPlayer.reverbZoneMix = sound2DB;
        BGMusicPlayer.Play();
    }

    public void PlayEffect(int effectNumber)
    {
        effectsPlayer.clip = soundEffects[effectNumber];
        effectsPlayer.volume = volume;
        effectsPlayer.pitch = pitch;
        effectsPlayer.mute = mute;
        effectsPlayer.loop = loop;
        effectsPlayer.reverbZoneMix = sound2D;
        effectsPlayer.Play();
    }
    public void SliderChange()
    {
        volume = volumeChanger.value;
        //volume = value);
        effectsPlayer.volume = volume;
    }
    public void MuteChange()
    {
        mute = muteChanger.isOn;
        effectsPlayer.mute = mute;
    }

    public void SliderChangeB()
    {
        volumeB = volumeChangerB.value;
        //volume = value);
        BGMusicPlayer.volume = volumeB;
    }
    public void MuteChangeB()
    {
        muteB = muteChangerB.isOn;
        BGMusicPlayer.mute = muteB;
        BGMusicPlayer.Pause();

        if (!muteB)
        {
            BGMusicPlayer.Play();
        }
    }

}
