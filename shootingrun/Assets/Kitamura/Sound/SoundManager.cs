using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static SoundManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public static SoundManager GetInstancs
    {
        get
        {
            return instance;
        }
    }

    [SerializeField] AudioClip _shot;
    [SerializeField] AudioClip _dead;
    [SerializeField] AudioClip _hit;
    AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void AudioSourcePlay(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
    }

    public void Shot() => AudioSourcePlay(_shot);
    public void Hit() => AudioSourcePlay(_hit);
    public void Dead () => AudioSourcePlay(_dead);
}
