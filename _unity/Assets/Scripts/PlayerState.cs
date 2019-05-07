using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
   public int UnlockedLevel { get; set; }
   public int CurrentLevel { get; set; }

   public  PlayerState()
   {
      UnlockedLevel = 2;
      CurrentLevel = 0;
   }

   public void SaveLevelPassed()
   {
      CurrentLevel++;
      UnlockedLevel = Mathf.Max(UnlockedLevel, CurrentLevel);
   }
}
