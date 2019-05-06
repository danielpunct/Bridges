using System.Collections;
using System.Collections.Generic;
using Gamelogic.Extensions;
using UnityEngine;

public class GameArena : Singleton<GameArena>
{
    public GameObject[] levelsPrefabs;

    public Transform levelHolder;

    Level _loadedLevel;

    public void _Reset()
    {
        if (_loadedLevel != null)
        {
            Destroy(_loadedLevel.gameObject);
        }
    }
    
    public void StartLevel(int index)
    {
        _Reset();

        _loadedLevel = Instantiate(levelsPrefabs[index], levelHolder).GetComponent<Level>();
    }
}
