using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotHitter : MonoBehaviour
{
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
           GameManager.Instance.PassedLevel();
        }
    }
}
