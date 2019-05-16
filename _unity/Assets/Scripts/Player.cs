using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject collideEffectHolder;
    public GameObject dieEffectHolder;
    public Level level;

    Rigidbody2D _rb;
    Sequence _seq;
    Vector2 _oldVelocity;

    float _clampedVelocity
    {
        get
        {
            if (_lastContactTime <= -1)
            {
                return 4;
            }
            
            var deltaTime = Time.time - _lastContactTime;
            return 4 + deltaTime*5;
        }
    }

    float _lastContactTime = -1;


    public SpringJoint2D spring;
    public Transform springAnchor;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        dieEffectHolder.SetActive(false);
        collideEffectHolder.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        var contactPoint = other.contacts[0];
        var impulse = contactPoint.normalImpulse;

        if (impulse > 2)
        {
            var g = Instantiate(collideEffectHolder, contactPoint.point, Quaternion.identity,
                transform.parent);
            g.SetActive(true);
            SoundManager.Instance.PlayCollide();
        }

        SetCollisionSpring(contactPoint);
    }

    void OnCollisionExit2D(Collision2D other)
    {
        _lastContactTime = Time.time;
    }

    void SetCollisionSpring( ContactPoint2D contactPoint)
    {
        springAnchor.SetParent(contactPoint.collider.transform);
        springAnchor.position = contactPoint.point;
        //spring.enabled = true;
    }


    public void Die()
    {
        GameManager.Instance.PlayerDied();

        GetComponent<Rigidbody2D>().isKinematic = true;

        SoundManager.Instance.PlayEnemyCollide();

        var g = Instantiate(dieEffectHolder, transform.position, Quaternion.identity,
            transform.parent);
        g.SetActive(true);
        gameObject.SetActive(false);
    }


    void FixedUpdate()
    {
        spring.connectedAnchor = springAnchor.position;
        if (spring.distance > 4)
        {
            spring.enabled = false;
        }

        var mag = _rb.velocity.magnitude;
        if (mag > _clampedVelocity)
        {
            var clamped = _rb.velocity.normalized * _clampedVelocity;
            _rb.velocity = clamped;
        }
    }
}