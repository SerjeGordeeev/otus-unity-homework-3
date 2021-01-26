using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySound : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField]
    private List<DataSound> dataSounds = new List<DataSound>();

    [SerializeField]
    private List<WeaponDataSound> weaponSounds = new List<WeaponDataSound>();

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Play(string nameClip)
    {
        SetAudioClipAndPlay(GetAudioClip(nameClip));
    }

    public void Play(Weapon weapon)
    {
        SetAudioClipAndPlay(GetWeaponSound(weapon));
    }

    private void SetAudioClipAndPlay(AudioClip audioClip)
    {
        _audioSource.clip = audioClip;
        _audioSource.Play();
    }

    private AudioClip GetAudioClip(string nameClip)
    {
        AudioClip clip = null;
        
        foreach (var sound in dataSounds)
        {
            if (sound.name == nameClip)
                clip = sound.audioClip;
        }

        return clip;
    }

    private AudioClip GetWeaponSound(Weapon weapon)
    {
        AudioClip clip = null;
        var weaponSoundData = weaponSounds.Find((item) => item.weapon == weapon);
        if (weaponSoundData != null)
        {
            clip = weaponSoundData.audioClip;
        }

        return clip;
    }
    
    [Serializable]
    private class DataSound
    {
        public string name;
        public AudioClip audioClip;
    }

    [Serializable]
    private class WeaponDataSound: DataSound
    {
        public Weapon weapon;
    }
}