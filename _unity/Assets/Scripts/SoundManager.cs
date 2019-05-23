using System.Collections;
using System.Collections.Generic;
using Gamelogic.Extensions;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource audioSource;
    public AudioClip collide;
    public AudioClip enemyCollide;
    public AudioClip outOfBounds;
    public AudioClip success;
    

    public void PlayCollide()
    {
        audioSource.PlayOneShot(collide);
    }

    public void PlayEnemyCollide()
    {
        audioSource.PlayOneShot(enemyCollide);
    }
    
    public void PlayOutOfBounds()
    {
        audioSource.PlayOneShot(outOfBounds);
    }
    
    public void PlaySuccess()
    {
        audioSource.PlayOneShot(success);
    }
    
    public void SetAudio(bool on)
    {
        audioSource.mute = !on;
        
        GameManager.Instance.Player.SaveSound(on);
    }
}
