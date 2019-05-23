using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HomeScreen : MonoBehaviour
{
   public TMP_Text levelText;

   public GameObject buttonOn;
   public GameObject buttonOff;
   
   public void OnPlayClick()
   {
      GameManager.Instance.PlayGame();
   }

   public void OnSoundOff()
   {
      buttonOn.SetActive(true);
      buttonOff.SetActive(false);

      SoundManager.Instance.SetAudio(true);
   }

   public void OnSoundOn()
   {
      buttonOn.SetActive(false);
      buttonOff.SetActive(true);
      
      SoundManager.Instance.SetAudio(false);
   }

   void OnEnable()
   {
      if (GameManager.Instance.Player == null)
      {
         gameObject.SetActive(false);
         return;
      }
      levelText.text = "LEVEL " + (GameManager.Instance.Player.CurrentLevel+1);

      if (GameManager.Instance.Player.Sound == 0)
      {
         OnSoundOn();
      }
      else
      {
         OnSoundOff();
      }
   }
}