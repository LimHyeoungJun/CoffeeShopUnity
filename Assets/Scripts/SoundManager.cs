using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<SoundManager>();
            }
            return m_instance;
        }
    }

    private static SoundManager m_instance;


    public AudioSource AudioSource;
    public AudioSource AudioSourceBGM;
    public AudioSource AudioSourceTalk;
    public AudioSource AudioSourceSonNimInOut;


    public AudioClip bgm;
    public AudioClip Drop;
    public AudioClip Get;
    public AudioClip SonnimIn;
    public AudioClip SonnimMal;
    public AudioClip True;
    public AudioClip False;
    public AudioClip ComplEt;
    public AudioClip ButtonClick;

    private void Start()
    {
        AudioSourceBGM.clip = bgm;
        AudioSourceBGM.loop = true;
        AudioSourceBGM.Play();
        AudioSourceTalk.clip = SonnimMal;
    }
    
    public void PlayDropSound()
    {
        AudioSource.clip = Drop;
        PlayClip();
    }
    public void PlayGetSound()
    {
        AudioSource.clip = Get;
        PlayClip();
    }
    public void PlaySonNimInSound()
    {
        AudioSourceSonNimInOut.clip = SonnimIn;
        AudioSourceSonNimInOut.Play();
        //PlayClip();
    }
    private void PlayClip()
    {
        AudioSource.Play();
    }
    public void PlayTalkingNPC()
    {
        AudioSourceTalk.Play();
    }
    public void PlayTrue()
    {
        AudioSource.clip = True;
        PlayClip();
    }
    public void PlayFalse()
    {
        AudioSource.clip = False;
        PlayClip();
    }
    public void PlayComplet()
    {
        AudioSource.clip = ComplEt;
        PlayClip();
    }
    public void PlayClickButtonSound()
    {
        AudioSource.clip = ButtonClick;
        AudioSource.Play();
    }

}
