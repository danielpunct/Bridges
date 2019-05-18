using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Transform pivot;

    Transform _tr;
    float _targetRotattion;

   public  Rigidbody2D _rb;

    void Awake()
    {
        _tr = transform;
    }

    void OnEnable()
    {
        TouchHandler.OnTouchRotate += Rotate;
    }

    void OnDisable()
    {
        TouchHandler.OnTouchRotate -= Rotate;
        
    }

    void Rotate(float rotation)
    {
        _targetRotattion += rotation;
    }

    void FixedUpdate()
    {
        if (_rb != null)
        {
            _rb.DORotate(_targetRotattion, Time.fixedDeltaTime);
        }
        else
        {
//            var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, _tr.eulerAngles.y, _targetRotattion);
//            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, 0.5f);

            pivot.DOLocalRotate(new Vector3(0, 0, _targetRotattion), Time.fixedDeltaTime);
        }
    }
}
