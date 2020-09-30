using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [Header("Sound Clips")]
    [SerializeField] private AudioClip footstepSound = null;
    [SerializeField] private AudioClip attackSound = null;
    [SerializeField] private AudioClip hitSound = null;
    [SerializeField] private AudioClip deadSound = null;

    [Header("Volume Settings")]
    [SerializeField] private float footstepVolume = 1;
    [SerializeField] private float attackVolume = 1;
    [SerializeField] private float hitVolume = 1;
    [SerializeField] private float dieVolume = 1;


    private AudioSource charAudio;

    private void Start()
    {
        charAudio = GetComponent<AudioSource>();
    }

    public void Footsteps()
    {
        if (!charAudio.isPlaying)
        {
            charAudio.PlayOneShot(footstepSound, footstepVolume);
        }
    }

    public void Attack()
    {
        charAudio.PlayOneShot(attackSound, attackVolume);
    }

    public void GetHit()
    {
        charAudio.PlayOneShot(hitSound, hitVolume);
    }

    public void Dead()
    {
        charAudio.PlayOneShot(deadSound, dieVolume);
    }

    public void StopSounds()
    {
        if (charAudio.isPlaying)
        {
            charAudio.Stop();
        }
    }
}
