using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{

    public static bool soundEnabled
    {
        set { PlayerPrefs.SetInt("Sound", value ? 1 : 0); }
        get { return PlayerPrefs.GetInt("Sound", 1) == 1; }
    }

    private AudioSource source;
    public static Sound the;

    public Image soundOnImage;

    public SoundFX pickupSound;
    public SoundFX runeSound;
    public SoundFX endSound;
    public SoundFX startSound;
    public SoundFX doorSlamSound;

    private void Awake()
    {
        if (the != null)
        {
            Destroy(the.gameObject);
        }

        source = GetComponent<AudioSource>();

        soundOnImage.gameObject.SetActive(soundEnabled);

        the = this;
    }

    public void PlaySound(SoundFX soundFX)
    {
        PlaySound(soundFX.GetClip(), soundFX.volume);
    }

    public void PlaySound(AudioClip clip, float volume)
    {
        if(soundEnabled)
        {
            source.PlayOneShot(clip, volume);
        }
    }

    public void SoundOn()
    {
        soundEnabled = true;
    }

    public void SoundOff()
    {
        soundEnabled = false;
    }

}
