using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
      public static GameManager Instance;
    public enum GameState { Menu,Game,LevelComplete,GameOver}

   private GameState gameState;
    public static Action<GameState> onGameStateChanged;
    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }




    void Start()
    {
       // PlayerPrefs.DeleteAll();
    }

    
    void Update()
    {
        
    }

    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        onGameStateChanged?.Invoke(gameState);
        Debug.Log("start" + gameState);
    }
    public bool ÝsGameState()
    {
        return gameState == GameState.Game;
    }
}
