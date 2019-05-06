using System.Collections;
using System.Collections.Generic;
using Gamelogic.Extensions;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    PlayerState Player { get; set; }
    
    void Start()
    {
        Player = new PlayerState();
        MenuManager.Instance._Reset();
        GameArena.Instance._Reset();
    }

    public void PlayGame()
    {
        GameArena.Instance.StartLevel(Player.CurrentLevel);
    }
}
