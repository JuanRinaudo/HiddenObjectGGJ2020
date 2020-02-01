using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundFX", menuName = "Data/SoundFX")]
public class SoundFX : ScriptableObject
{

    public AudioClip[] clips;
    public float volume = 1;

    public AudioClip GetClip()
    {
        return clips[Random.Range(0, clips.Length)];
    }

}
