using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
   public int MaxUnlockedLevel { get; set; }
   public int CurrentLevel { get; set; }

   public  PlayerState()
   {
      MaxUnlockedLevel = GameManager.Instance.LoadedLevels - 1;
      CurrentLevel = 0;
   }

   public void SaveLevelPassed()
   {
      CurrentLevel++;
      MaxUnlockedLevel = Mathf.Max(MaxUnlockedLevel, CurrentLevel);
   }
}
