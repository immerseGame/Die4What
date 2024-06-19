using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    AudioMixer gameAudioMixer;

    protected override void Awake()
    {
        base.Awake();
        LoadAudioSettings();
    }

    void LoadAudioSettings()
    {
        gameAudioMixer = Resources.Load<AudioMixer>("Audio/GameAudioMixer");

        if (gameAudioMixer == null)
        {
            Debug.LogError("Failed to load mixer.");
            return;
        }

        ChangeMusicVolume(PlayerPrefs.HasKey("music") ? PlayerPrefs.GetFloat("music") : 0.5f);
        ChangeMusicVolume(PlayerPrefs.HasKey("Voice") ? PlayerPrefs.GetFloat("Voice") : 0.5f);
        ChangeMusicVolume(PlayerPrefs.HasKey("SFX") ? PlayerPrefs.GetFloat("SFX") : 0.5f);

    }

    public void ChangeMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("music", volume);
        gameAudioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }

    public void ChangeSFXVolume(float volume)
    {
        PlayerPrefs.SetFloat("SFX", volume);
        gameAudioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);

    }

    public void ChangeVoiceVolume(float volume)
    {
        PlayerPrefs.SetFloat("Voice", volume);
        gameAudioMixer.SetFloat("Voice", Mathf.Log10(volume) * 20);

    }

}
