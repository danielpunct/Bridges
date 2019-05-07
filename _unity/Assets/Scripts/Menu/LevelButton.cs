using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
   public TMP_Text valueText;

   int _levelIndex;
   
   public void Init(int levelIndex)
   {
      _levelIndex = levelIndex;
      
      valueText.text = (_levelIndex + 1).ToString();
   }

   public void OnClick()
   {
      if (GameManager.Instance.Player.MaxUnlockedLevel < _levelIndex)
      {
         return;
      }
      
      GameManager.Instance.PlayLevel(_levelIndex);
   }
}
