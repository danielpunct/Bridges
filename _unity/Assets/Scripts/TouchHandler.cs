using System;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Extensions;
using Lean.Touch;
using UnityEngine;

public class TouchHandler : Singleton<TouchHandler>
{
    public static Action<float> OnTouchRotate;
    private const float ClampValue = 20;

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

    void OnGesture(List<LeanFinger> fingers)
    {
        if (GameManager.Instance.State != GameState.Play)
        {
            return;
        }

        var delta = LeanGesture.GetScreenDelta(fingers);

        var adjusted = Mathf.Clamp(-(delta.x + delta.y) * 0.37f, -ClampValue, ClampValue);
        
        OnTouchRotate?.Invoke(adjusted);
    }
}