using DG.Tweening;
using UnityEngine;

public class TitleAnimator : MonoBehaviour
{
    public Transform titleHolder;
    public Transform ballHolder;
   public  AnimationCurve ballCurve;
    Sequence _seq;
    
    void OnEnable()
    {
        ballHolder.DOLocalMoveY(700,0);
        
        
        _seq?.Kill();

        _seq = DOTween.Sequence()
            .Insert(0, ballHolder.DOLocalMoveY(0, 0.6f).SetEase(ballCurve))
            .Insert(0.6f, titleHolder.DOPunchScale(Vector3.one * 0.2f, 1f, 4, 0.3f));

    }
}
