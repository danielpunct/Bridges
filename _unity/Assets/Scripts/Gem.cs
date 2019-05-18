using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public Transform graphicHolder;
    public GameObject effectHolder;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           Debug.Log("gem!");
           GetComponent<Collider2D>().enabled = false;
           
           GameManager.Instance.PlayerHitGem(this);
        }
    }
    
}
