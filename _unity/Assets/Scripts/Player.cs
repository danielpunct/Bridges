using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject collideEffectHolder;
    public GameObject dieEffectHolder;
    
    Rigidbody2D _rb;
    Sequence _seq;
    Vector2 oldVelocity;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        dieEffectHolder.SetActive(false);
        collideEffectHolder.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        var impulse = other.contacts[0].normalImpulse;
        var v = _rb.velocity.magnitude;

        if (impulse > 1)
        {
            var g =Instantiate(collideEffectHolder, other.contacts[0].point, Quaternion.identity,
                transform.parent);
            g.SetActive(true);
            SoundManager.Instance.PlayCollide();
        }
    }

    public void Die()
    {
        GameManager.Instance.PlayerDied();

        GetComponent<Rigidbody2D>().isKinematic = true;
        
        SoundManager.Instance.PlayEnemyCollide();
        
        var g =Instantiate(dieEffectHolder, transform.position, Quaternion.identity,
            transform.parent);
        g.SetActive(true);
        gameObject.SetActive(false);
        
    }

    float max = 0f;
    void FixedUpdate()
    {
        var velo = _rb.velocity;
        
        var mag = _rb.velocity.magnitude;
        var oldMag = oldVelocity.magnitude;
        
        if (mag != 0 && oldMag != 0)
        {
            if (oldMag / mag < 0.8f)
            {
                _rb.velocity = velo.normalized * 1.1f;
            }
        }

        if (mag > max)
        {
//            Debug.Log(v);
            max = mag;
        }

        if (mag > 10)
        {
            var clamped = _rb.velocity.normalized * 3;
            _rb.velocity = clamped;
        }

        oldVelocity = velo;
    }
}
