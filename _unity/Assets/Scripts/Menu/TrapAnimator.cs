using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TrapAnimator : MonoBehaviour
{
   public float min;
   public float max = 1;
   public Transform spikes;
   public AnimationCurve scaleCurve;

   Sequence _seq;

   void OnEnable()
   {
      spikes.transform.DOScale(min, 0.5f);
      InvokeRepeating("Idle", 1, 2.4f);
   }

   public void Idle()
   {
      _seq?.Kill();
      
      _seq = DOTween.Sequence()
         .Insert(0, t: spikes.DOScale(Vector3.one  * max,2).SetEase(scaleCurve));
   }
}
