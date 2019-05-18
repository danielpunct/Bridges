using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class GameScreen : MonoBehaviour
{
   public TMP_Text outOfBoundsText;
   public GameObject levelHolder;
   public TMP_Text levelText;
   public TMP_Text gemCountText;
   public Transform gemIconHolder;

   public AnimationCurve gemScaleCurve;
   Sequence _gemSeq;

   public void _Reset(int levelIndex, int gemCount)
   {
      outOfBoundsText.gameObject.SetActive(false);
      gemCountText.text = gemCount.ToString();
      levelHolder.SetActive(true);
      levelText.text = "LEVEL " + (levelIndex + 1);
   }

   public void ShowOutOfBounds()
   {
      levelHolder.SetActive(false);
      outOfBoundsText.gameObject.SetActive(true);
   }

   public void ShowReceiveGem(Gem gem)
   {
      var destinationPosition = gemIconHolder.position;
      destinationPosition.z = 0;
      gem.transform.SetParent(MenuManager.Instance.overGameCanvas);
      _gemSeq?.Kill();
      _gemSeq = DOTween.Sequence()
         .Insert(0, gem.graphicHolder.DOPunchScale(Vector3.one * 0.8f, 0.4f, 4, 0.6f))
         .Insert(0,
            gem.transform
               .DOLocalMove(gem.transform.localPosition + new Vector3(Random.Range(-25f, 25f), 40f, 0), 1)
               .SetEase(Ease.OutCirc))
         .InsertCallback(0.2f, () => gem.effectHolder.SetActive(true))
         .Insert(1, gem.transform.DOMove(destinationPosition, 0.8f).SetEase(Ease.InQuad))

         .Insert(1, gem.transform.DOScale(gem.transform.localScale * 0.8f, 0.8f).SetEase(Ease.InQuad))
         .Insert(1.8f, gemIconHolder.DOPunchScale(Vector3.one * 0.8f, 0.4f, 10, 0.6f))
         .InsertCallback(1.8f, () =>
         {
            gem.gameObject.SetActive(false);
            gemCountText.text = GameManager.Instance.Player.GemCount.ToString();
         });
   }
}
