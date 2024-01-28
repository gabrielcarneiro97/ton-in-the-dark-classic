using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource musicSource, cricketSource, stepsSource, playerEffectsSource, effectsSource, fireflySource;

    public AudioClip musicClip, cricketsClip, stepsClip, fireflyesClip, playerInteractClip, coverClip, doorsClip;

    public float ambientVolumeModifier = .3f;
    public float effectsVolume = 1f, ambientVolume = 1f;

    void Start()
    {
        ChangeAmbientVolume(ambientVolume);
        ChangeEffectsVolume(effectsVolume);
        PlayMusic();
        PlayCrickets();
        PlayFireflyes();
    }

    public void PlayMusic()
    {
        musicSource.clip = musicClip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayCrickets()
    {
        cricketSource.clip = cricketsClip;
        cricketSource.loop = true;
        cricketSource.Play();
    }

    public void PlaySteps()
    {
        stepsSource.clip = stepsClip;
        stepsSource.Play();
    }

    public void PlayFireflyes()
    {
        fireflySource.clip = fireflyesClip;
        fireflySource.loop = true;
        fireflySource.Play();
    }

    public void PlayPlayerInteract()
    {
        playerEffectsSource.clip = playerInteractClip;
        playerEffectsSource.Play();
    }

    public void PlayCover()
    {
        effectsSource.clip = coverClip;
        effectsSource.Play();
    }

    public void PlayDoors()
    {
        effectsSource.clip = doorsClip;
        effectsSource.Play();
    }

    public void ChangeEffectsVolume(float value)
    {
        effectsVolume = value;
        effectsSource.volume = effectsVolume;
        playerEffectsSource.volume = effectsVolume;
        stepsSource.volume = effectsVolume;
    }

    public void ChangeAmbientVolume(float value)
    {
        ambientVolume = value * ambientVolumeModifier;
        cricketSource.volume = ambientVolume;
        fireflySource.volume = ambientVolume;
        musicSource.volume = ambientVolume;
    }

}
