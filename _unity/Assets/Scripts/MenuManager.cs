using Gamelogic.Extensions;
using UnityEngine;

public class MenuManager : Singleton<MenuManager>
{
    public GameObject homeScreen;
    public GameScreen gameScreen;
    public LevelsScreen levelsScreen;

    public Transform overGameCanvas;
    public GameObject levelsButton;
    


    public void Init()
    {
        levelsScreen.Init(GameManager.Instance.Player.MaxLoadedLevel+1);
        ShowHomeMenu();
    }

    public void ShowGameMenu(int levelIndex, int gemCount)
    {
        levelsScreen.gameObject.SetActive(false);
        homeScreen.SetActive(false);
        gameScreen.gameObject.SetActive(true);
        levelsButton.SetActive(true);
        
        gameScreen._Reset(levelIndex, gemCount);
    }

    public void ShowHomeMenu()
    {
        homeScreen.SetActive(true);
        gameScreen.gameObject.SetActive(false);
        levelsScreen.gameObject.SetActive(false);
        levelsButton.SetActive(true);
    }
    
    public void ShowLevelsMenu()
    {
        levelsScreen.gameObject.SetActive(true);
        levelsScreen.RefreshLevels();
        levelsButton.SetActive(false);

    }

    public void HideLevelsScreen()
    {
        levelsScreen.gameObject.SetActive(false);
        levelsButton.SetActive(true);
    }
    
}