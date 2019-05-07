using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotHitter : MonoBehaviour
{
    public GameObject winEffectGO;

    void OnEnable()
    {
        winEffectGO.SetActive(false);
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
        }
    }
}
