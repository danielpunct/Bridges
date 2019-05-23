using Gamelogic.Extensions;
using UnityEngine;

public class GameArena : Singleton<GameArena>
{
    public GameObject[] levelsPrefabs;

    public Transform levelHolder;

    Level _loadedLevel;
    public PotHitter currentPot;


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

        if (levelsPrefabs.Length > index % 30)
        {
            _loadedLevel = Instantiate(levelsPrefabs[index % 30], levelHolder).GetComponent<Level>();
        }
    }

    public void RegisterCurrentPot(PotHitter pot)
    {
        this.currentPot = pot;
    }
}
