using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HomeScreen : MonoBehaviour
{
   public TMP_Text levelText;
   public void OnPlayClick()
   {
      GameManager.Instance.PlayGame();
   }

   void OnEnable()
   {
      if (GameManager.Instance.Player == null)
      {
         gameObject.SetActive(false);
         return;
      }
      levelText.text = "LEVEL " + (GameManager.Instance.Player.CurrentLevel+1);
   }
}
