using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager;
    [SerializeField] private AudioSource backgoundMusic, hitSFX, DeathSFX, JumpSFX, ProyectileShootSFX, VictorySFX; 
    void Awake()
    {
        if (AudioManager.audioManager != null && AudioManager.audioManager != this)
        {
            Destroy(gameObject);
        }
        else
        {
            AudioManager.audioManager = this;
            DontDestroyOnLoad(gameObject);
            backgoundMusic.Play();
        }
            

    }

    public void PlayHit()
    {
        hitSFX.Play();
    }

    public void PlayDeath()
    {
        DeathSFX.Play();
    }

    public void PlayJump()
    {
        JumpSFX.Play();
    }

    public void PlayProyectile()
    {
        ProyectileShootSFX.Play();
    }

    public void PlayWin()
    {
        VictorySFX.Play();
    }

}
