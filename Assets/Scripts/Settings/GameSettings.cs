using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/New GameSettings", order = 0)]

public class GameSettings : ScriptableObject
{

    public int minTargetEnemies = 5, maxTargetEnemies = 10;
    public float minEnemySpawnDelay = 0.3f, maxEnemySpawnDelay = 1f;
    public float minEnemySpeed = 2f, maxEnemySpeed = 5f;
    public int enemyHealth = 10;
    public float playerMoveSpeed = 10f;
    public float playerFireRange = 3f;
    public float playerFireRate = 0.2f;
    public int playerDamage = 5;
    public float playerBulletSpeed = 30f;
    public int playerHealth = 3;
}
