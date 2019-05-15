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
    const float ClampedVelocity = 4f;


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

        if (impulse > 10)
        {
            var g = Instantiate(collideEffectHolder, contactPoint.point, Quaternion.identity,
                transform.parent);
            g.SetActive(true);
            SoundManager.Instance.PlayCollide();
        }

        SetCollisionSpring(contactPoint);
    }

    void SetCollisionSpring( ContactPoint2D contactPoint)
    {
        springAnchor.SetParent(contactPoint.collider.transform);
        springAnchor.position = contactPoint.point;
        spring.enabled = true;
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
        if (mag > ClampedVelocity)
        {
            var clamped = _rb.velocity.normalized * ClampedVelocity;
            _rb.velocity = clamped;
        }
    }
}