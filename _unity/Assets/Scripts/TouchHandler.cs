using System;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Extensions;
using Lean.Touch;
using UnityEngine;

public class TouchHandler : Singleton<TouchHandler>
{
    public static Action<float> OnTouchRotate;
    float _clampValue = 20;
    
    protected virtual void OnEnable()
    {
        // Hook into the events we need
        LeanTouch.OnGesture += OnGesture;
    }

    protected virtual void OnDisable()
    {
        // Unhook the events
        LeanTouch.OnGesture -= OnGesture;
    }

    public void OnGesture(List<LeanFinger> fingers)
    {
        if (GameManager.Instance.State != GameState.Play)
        {
            return;
        }

        var delta = LeanGesture.GetScreenDelta(fingers);

        var adjusted = Mathf.Clamp(-(delta.x + delta.y) * 0.3f, -_clampValue, _clampValue);
        
        OnTouchRotate?.Invoke(adjusted);
    }



}