using Gamelogic.Extensions;
using UnityEngine;

public class MenuManager : Singleton<MenuManager>
{
    public GameObject homeScreen;
    public GameObject gameScreen;

    void Start()
    {
        _Reset();
    }

    public void _Reset()
    {
        ShowHomeMenu();
    }

    public void ShowGameMenu()
    {
        homeScreen.SetActive(false);
        gameScreen.SetActive(true);
    }

    public void ShowHomeMenu()
    {
        homeScreen.SetActive(true);
        gameScreen.SetActive(false);
    }
}