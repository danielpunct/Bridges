using DG.Tweening;
using Gamelogic.Extensions;

public class GameManager : Singleton<GameManager>
{
    public int LoadedLevels => GameArena.Instance.levelsPrefabs.Length;

    public PlayerState Player { get; private set; }
    public GameState State { get; private set; }

    Sequence _seq;
    
    void Start()
    {
        Player = new PlayerState();
        
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

        MenuManager.Instance.ShowGameMenu(levelIndex);
        GameArena.Instance.StartLevel(levelIndex);
        Player.SetLevelStart(levelIndex);
    }

    public void PassedLevel()
    {
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
        State = GameState.LevelEnding;
        
        _seq?.Kill();
        _seq = DOTween.Sequence()
            .InsertCallback(0.3f, () => PlayLevel(Player.CurrentLevel));
    }

    public void OnMenuButtonClick()
    {
        State = GameState.Menu;
        MenuManager.Instance.ShowLevelsMenu();
    }
}

public enum GameState
{
    Play,
    LevelEnding,
    Menu
}