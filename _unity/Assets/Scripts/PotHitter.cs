using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotHitter : MonoBehaviour
{
    public GameObject winEffectGO;

    public GameObject defaultFace;
    public GameObject sadFace;
    public GameObject happyFace;
    
    public enum faceState { idle, sad, happy }

    void OnEnable()
    {
        winEffectGO.SetActive(false);
        
        GameArena.Instance.RegisterCurrentPot(this);
        
        SetFace(faceState.idle);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (GameManager.Instance.State != GameState.Play)
        {
            return;
        }
        
        if (other.transform.CompareTag("Player"))
        {
           GameManager.Instance.PassedLevel();
           
           winEffectGO.SetActive(true);
           
           SetFace(faceState.happy);
        }
    }

    public void ShowOutOfBounds()
    {
        SetFace(faceState.sad);
    }

    public void SetFace(faceState face)
    {
        defaultFace.SetActive(face == faceState.idle);
        sadFace.SetActive(face == faceState.sad);
        happyFace.SetActive(face == faceState.happy);
    }
}
