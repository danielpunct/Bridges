using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Transform pivot;
    
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
        pivot.Rotate(new Vector3(0,0,rotation));
    }
}
