using System;
using UnityEngine;

[Serializable]
public class SoundAudioClip 
{
    [field : SerializeField] public Sound sound { get; private set; }
    [field: SerializeField]  public AudioClip audioClip { get; private set; }
}
