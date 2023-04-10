using System;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect;

    public void PlayJumpSound()
    {
        jumpSoundEffect.Play();
    }

    public void PlayDeathSound()
    {
        jumpSoundEffect.Play();
    }
}
