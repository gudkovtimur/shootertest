using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel 
{
    
    public enum GameState
    {
        Playing, GameOver
    }

    public GameState state = GameState.Playing;

    public bool IsPlaying => state == GameState.Playing;

    public float nextSpawnEnemyTime;
    public int targetEnemies, spawnedEnemies, killedEnemies;

    public GameModel(GameSettings settings)
    {
        targetEnemies = Random.Range(settings.minTargetEnemies, settings.maxTargetEnemies);
        state = GameState.Playing;
    }
    

}
