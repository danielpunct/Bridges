using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Gamelogic.Extensions;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    PlayerState Player { get; set; }
    public GameState State { get; private set; }

    Sequence _seq;
    
    void Start()
    {
        Player = new PlayerState();
        
        MenuManager.Instance._Reset();
        GameArena.Instance._Reset();

        State = GameState.Menu;
    }

    public void PlayGame()
    {
       StartNextLevel();
    }

    public void PassedLevel()
    {
        State = GameState.LevelEnding;
        
        Player.SaveLevelPassed();
        
        _seq?.Kill();
        _seq = DOTween.Sequence()
            .InsertCallback(3, StartNextLevel);
    }

    void StartNextLevel()
    {
        State = GameState.Play;

        GameArena.Instance.StartLevel(Player.CurrentLevel);
    }

}

public enum GameState
{
    Play,
    LevelEnding,
    Menu
}