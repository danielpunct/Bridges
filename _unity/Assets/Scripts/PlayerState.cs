﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
   public int MaxLoadedLevel { get; set; }
   public int MaxUnlockedLevel { get; set; }
   public int CurrentLevel { get; set; }
   public int GemCount { get; set; }

   string MaxUnlockedLevel_tag = "MaxUnlockedLevel";
   string CurrentLevel_tag = "CurrentLevel";
   string GemCount_tag = "GemCount";

   public  PlayerState()
   {
      MaxLoadedLevel =  GameManager.Instance.LoadedLevels - 1;
      MaxUnlockedLevel = PlayerPrefs.GetInt(MaxUnlockedLevel_tag, 0);
      CurrentLevel = PlayerPrefs.GetInt(CurrentLevel_tag, 0);
      GemCount = PlayerPrefs.GetInt(GemCount_tag, 0);
   }

   public void SaveLevelPassed()
   {
      CurrentLevel++;
      MaxUnlockedLevel = Mathf.Max(MaxUnlockedLevel, CurrentLevel );

      PlayerPrefs.SetInt(CurrentLevel_tag, CurrentLevel + 1);
      PlayerPrefs.SetInt(MaxUnlockedLevel_tag, MaxUnlockedLevel);
   }

   public void SaveReceiveGem()
   {
      GemCount++;
      PlayerPrefs.SetInt(GemCount_tag, GemCount);
   }

   public void SetLevelStart(int currentLevel)
   {
      CurrentLevel = currentLevel;
      PlayerPrefs.SetInt(CurrentLevel_tag, CurrentLevel);
   }
   
}
