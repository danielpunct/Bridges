using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject collideEffectHolder;
    
    Rigidbody2D _rb;
    Sequence _seq;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        var impulse = other.contacts[0].normalImpulse;
        Debug.Log(impulse);
        var v = _rb.velocity.magnitude;

        if (impulse > 1)
        {
            var g =Instantiate(collideEffectHolder, other.contacts[0].point, Quaternion.identity,
                transform.parent);
            g.SetActive(true);
        }
    }

    public void Die()
    {
        GameManager.Instance.PlayerDied();

        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    float max = 0f;
    void FixedUpdate()
    {
        
        var v = _rb.velocity.magnitude;
        
        if (v > max)
        {
//            Debug.Log(v);
            max = v;
        }

        if (v > 10)
        {
            var clamped = _rb.velocity.normalized * 3;
            _rb.velocity = clamped;
        }
    }
}
