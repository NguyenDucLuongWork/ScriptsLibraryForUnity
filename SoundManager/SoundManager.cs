using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour 
{
    [field: SerializeField] private GameAssets gameAssets;
    private Dictionary<Sound, float> soundTimerDictionary;

    private GameObject oneShotGameObject;
    private AudioSource oneShotAudioSource;

    private void Awake()
    {
        Initialize();
    }
    public void Initialize()
    {
        soundTimerDictionary = new Dictionary<Sound, float>();
        soundTimerDictionary[Sound.Shoot] = 0f;
    }

    public void PlaySound(Sound sound, Vector3 position)
    {
        if (CanPlaySound(sound))
        {
            GameObject soundGameObject = new GameObject("Sound");
            soundGameObject.transform.position = position;
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.clip = GetAudioClip(sound);
            audioSource.PlayOneShot(GetAudioClip(sound));

            Object.Destroy(soundGameObject, audioSource.clip.length);
        }
    }
    public void PlaySound(Sound sound)
    {
        if(CanPlaySound(sound))
        {
            if(oneShotGameObject == null)
            {
                oneShotGameObject = new GameObject("Sound");
                oneShotAudioSource = oneShotGameObject.AddComponent<AudioSource>();
            }
            oneShotAudioSource.PlayOneShot(GetAudioClip(sound));
        }
        
    }

    private bool CanPlaySound(Sound sound)
    {
        switch (sound)
        {
            default: 
                return true;
            case Sound.Shoot:
                if (soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float playerMoveTimeMax = 0.05f;
                    if(lastTimePlayed + playerMoveTimeMax < Time.time)
                    {
                        soundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
                //break;

        }
    }

    private AudioClip GetAudioClip(Sound sound)
    {
        foreach(SoundAudioClip soundAudioClip in gameAssets.soundAudioClipArray)
        {
            if(soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound" + sound + " was not found!");
        return null;
    }

    private void CheckAudioData()
    {

    }

}

public static class StaticSoundManager
{
    public static void AddButtonSounds(this Button button)
    {
        //sample
        /*
        button.onClick += () => SoundManager.PlaySound(Sound.Shoot);
        button.OnPointerEnter += () => SoundManager.PlaySound(Sound.Shoot);
        */
    }
}
