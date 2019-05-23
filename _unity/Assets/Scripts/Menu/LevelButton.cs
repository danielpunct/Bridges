using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
   public TMP_Text valueText;
   public Image buttonFace;

   public Sprite visited;
   public Sprite current;
   public Sprite locked;

   enum faceState { current, locked, visited}
   int _levelIndex;
   
   public void Init(int levelIndex)
   {
      _levelIndex = levelIndex;
      
      valueText.text = (_levelIndex + 1).ToString();
   }


   public void Refresh()
   {
      if (GameManager.Instance.Player.CurrentLevel == _levelIndex)
      {
         SwitchFace(faceState.current);
      }

      else if (GameManager.Instance.Player.MaxUnlockedLevel >= _levelIndex)
      {
         SwitchFace(faceState.visited);
      }

      else
      {
         SwitchFace(faceState.locked);
      }
   }

   void SwitchFace(faceState state)
   {
      switch (state)
      {
         case faceState.current:
            buttonFace.sprite = current;
            break;
         case faceState.locked:
            buttonFace.sprite = locked;
            break;
         case faceState.visited:
            buttonFace.sprite = visited;
            break;
         default:
            buttonFace.sprite = locked;
            break;
      }
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
