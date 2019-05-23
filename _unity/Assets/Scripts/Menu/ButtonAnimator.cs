using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;

public class ButtonAnimator : MonoBehaviour
{
   Transform _tr;
   Sequence _seq;

   void Awake()
   {
      _tr = transform;
   }

   void OnEnable()
   {
      InvokeRepeating("Beat", 3, 3);
   }

   public void Beat()
   {
      _seq?.Kill();

      _seq = DOTween.Sequence()
         .Insert(0, t: _tr.DOPunchScale(Vector3.one * 0.1f,
            duration: 1f,vibrato: 4,elasticity: 0.6f));
   }
}
