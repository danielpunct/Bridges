using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScreen : MonoBehaviour
{
   public TMP_Text outOfBoundsText;
   public GameObject levelHolder;
   public TMP_Text levelText;

   public void _Reset(int levelIndex)
   {
      outOfBoundsText.gameObject.SetActive(false);
      levelHolder.SetActive(true);
      levelText.text = "LEVEL " + (levelIndex + 1);
   }

   public void ShowOutOfBounds()
   {
      levelHolder.SetActive(false);
      outOfBoundsText.gameObject.SetActive(true);
   }
   
   
}
