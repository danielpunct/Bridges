using DG.Tweening;
using Gamelogic.Extensions;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int LoadedLevels => GameArena.Instance.levelsPrefabs.Length * 7;

    public PlayerState Player { get; private set; }

    public GameState _state;

    public GameState State
    {
        get => _state;
        set
        {
            cacheState = _state;
            _state = value;
        }
    }

    GameState cacheState;
    
    Sequence _seq;

    void Awake()
    {
        Player = new PlayerState();
    }

    void Start()
    {
        
        MenuManager.Instance.Init();
        GameArena.Instance._Reset();

        State = GameState.Menu;
    }

    public void PlayGame()
    {
        PlayLevel(Player.CurrentLevel);
    }

    public void PlayLevel(int levelIndex)
    {
        _seq?.Kill();
        State = GameState.Play;

        MenuManager.Instance.ShowGameMenu(levelIndex, Player.GemCount);
        GameArena.Instance.StartLevel(levelIndex);
        Player.SetLevelStart(levelIndex);
    }

    public void PassedLevel()
    {
        SoundManager.Instance.PlaySuccess();
        State = GameState.LevelEnding;
        
        Player.SaveLevelPassed();
        
        _seq?.Kill();
        _seq = DOTween.Sequence()
            .InsertCallback(3, () => PlayLevel(Player.CurrentLevel));
    }

    public void PlayerDied()
    {
        State = GameState.LevelEnding;
        
        _seq?.Kill();
        _seq = DOTween.Sequence()
            .InsertCallback(1, () => PlayLevel(Player.CurrentLevel));
    }

    public void PlayerOutOfBounds()
    {
        MenuManager.Instance.gameScreen.ShowOutOfBounds();
        GameArena.Instance.currentPot.ShowOutOfBounds();
        State = GameState.LevelEnding;
        
        _seq?.Kill();
        _seq = DOTween.Sequence()
            .InsertCallback(0.7f, () => PlayLevel(Player.CurrentLevel));
    }

    public void OnMenuButtonClick()
    {
        State = GameState.Menu;
        MenuManager.Instance.ShowLevelsMenu();
    }

    public void PlayerHitGem(Gem gem)
    {
        MenuManager.Instance.gameScreen.ShowReceiveGem(gem);
        Player.SaveReceiveGem(Player.CurrentLevel);
    }

    public void OnBackFromLevelsClick()
    {
        State = cacheState;
        MenuManager.Instance.HideLevelsScreen();
    }
}

public enum GameState
{
    Play,
    LevelEnding,
    Menu
}