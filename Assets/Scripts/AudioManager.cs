using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip burstSound;
    [SerializeField] AudioClip victorySound;
    [SerializeField] AudioClip[] pickSounds;

    private static AudioManager instance;

    public static AudioManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        instance = this;
    }

    public void PlayBurst()
    {
        audioSource.PlayOneShot(burstSound);
    }

    public void PlayVictory()
    {
        audioSource.PlayOneShot(victorySound);
    }

    public void PlayPick()
    {
        int soundIndex = Random.Range(0, pickSounds.Length);
        audioSource.PlayOneShot(pickSounds[soundIndex]);
    }
}
