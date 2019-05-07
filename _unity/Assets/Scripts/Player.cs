﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void Die()
    {
        GameManager.Instance.PlayerDied();

        GetComponent<Rigidbody2D>().isKinematic = true;
    }
}