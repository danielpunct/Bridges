using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounceHitter : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.Instance.State == GameState.Play)
            {
                GameManager.Instance.PlayerOutOfBounds();
            
                SoundManager.Instance.PlayOutOfBounds();
            }
        }
        else
        {
            other.gameObject.SetActive(false);
        }
    }
}
