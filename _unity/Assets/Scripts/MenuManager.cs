using Gamelogic.Extensions;
using UnityEngine;

public class MenuManager : Singleton<MenuManager>
{
    public GameObject homeScreen;
    public GameScreen gameScreen;
    public LevelsScreen levelsScreen;


    public void Init()
    {
        levelsScreen.Init(GameManager.Instance.Player.MaxLoadedLevel+1);
        ShowHomeMenu();
    }

    public void ShowGameMenu(int levelIndex)
    {
        levelsScreen.gameObject.SetActive(false);
        homeScreen.SetActive(false);
        gameScreen.gameObject.SetActive(true);
        
        gameScreen._Reset(levelIndex);
    }

    public void ShowHomeMenu()
    {
        homeScreen.SetActive(true);
        gameScreen.gameObject.SetActive(false);
        levelsScreen.gameObject.SetActive(false);
    }
    
    public void ShowLevelsMenu()
    {
        levelsScreen.gameObject.SetActive(true);
        homeScreen.SetActive(false);
        gameScreen.gameObject.SetActive(false);
    }
}