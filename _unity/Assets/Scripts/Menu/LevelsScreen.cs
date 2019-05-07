using System.Collections;
using System.Collections.Generic;
using Gamelogic.Extensions;
using UnityEngine;

public class LevelsScreen : MonoBehaviour
{
  public GameObject levelPrefab;
  public Transform levelsHolder;

  LevelButton[] loadedButtons;


  public void Init(int maxLevel)
  {
    levelsHolder.DestroyChildren();
    
    var buttons = new List<LevelButton>();
    for (int i = 0; i < maxLevel; i++)
    {
      var level = Instantiate(levelPrefab, levelsHolder).GetComponent<LevelButton>();

      level.Init(i);
      buttons.Add(level);
    }

    loadedButtons = buttons.ToArray();
  }
}
