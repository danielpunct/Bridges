﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerState 
{
   public int MaxLoadedLevel { get; set; }
   public int MaxUnlockedLevel { get; set; }
   public int CurrentLevel { get; set; }
   public int Sound { get; private set; }
   public int GemCount { get; private set; }
   readonly int[] _collectedGems;

   string MaxUnlockedLevel_tag = "MaxUnlockedLevel";
   string CurrentLevel_tag = "CurrentLevel";
   string GemCount_tag = "GemCount";
   string GemCollected_tag = "GemCollected";
   string Sound_tag = "Sound";

   public  PlayerState()
   {
      _collectedGems = new int[GameManager.Instance.LoadedLevels];

      var collectedString = PlayerPrefs.GetString(GemCollected_tag, "");
      if (!string.IsNullOrEmpty(collectedString))
      {
         _collectedGems = collectedString.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
      }
      MaxLoadedLevel =  GameManager.Instance.LoadedLevels - 1;
      MaxUnlockedLevel = PlayerPrefs.GetInt(MaxUnlockedLevel_tag, 0);
      CurrentLevel = PlayerPrefs.GetInt(CurrentLevel_tag, 0);
      GemCount = PlayerPrefs.GetInt(GemCount_tag, 0);
      Sound = PlayerPrefs.GetInt(Sound_tag, 1);
   }

   public void SaveSound(bool on)
   {
      Sound = on ? 1 : 0;
      PlayerPrefs.SetInt(Sound_tag, Sound);
   }
   
   public void SaveLevelPassed()
   {
      FbManager.Instance.LogEvent(CurrentLevel);
      CurrentLevel++;
      MaxUnlockedLevel = Mathf.Max(MaxUnlockedLevel, CurrentLevel );

      PlayerPrefs.SetInt(CurrentLevel_tag, CurrentLevel + 1);
      PlayerPrefs.SetInt(MaxUnlockedLevel_tag, MaxUnlockedLevel);
   }

   public void SaveReceiveGem(int levelIndex)
   {
      GemCount++;
      _collectedGems[levelIndex] = 1;
      PlayerPrefs.SetInt(GemCount_tag, GemCount);
      PlayerPrefs.SetString(GemCollected_tag, string.Join("",_collectedGems));
   }

   public void SetLevelStart(int currentLevel)
   {
      CurrentLevel = currentLevel;
      PlayerPrefs.SetInt(CurrentLevel_tag, CurrentLevel);
   }

   public bool IsGemCollected(int levelIndex)
   {
      return _collectedGems[levelIndex] != 0;
   }
   
}
