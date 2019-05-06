using System;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Extensions;
using Lean.Touch;
using UnityEngine;

public class TouchHandler : Singleton<TouchHandler>
{
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
        var delta = LeanGesture.GetScreenDelta(fingers);

        OnTouchRotate?.Invoke(delta.x * 0.5f);
    }

    public void InterruptSession()
    {
//        LeanTouch.
    }

    public static Action<float> OnTouchRotate;
}