using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameView : BaseView
{

    public GameSettings settings;
    
    public PlayerView playerView;
    public EnemyFactory enemyFactory;
    public SpriteRenderer finishLine;
    public GameUI ui;

    public Transform[] enemySpawnPoints;

    private List<EnemyView> activeEnemies = new List<EnemyView>();

    private GameModel model;

    protected override void Awake()
    {
        model = new GameModel(settings);
        playerView.Initialize(settings, finishLine, ref activeEnemies, OnPlayerHealthChanged);
        ui.OnRestartClick += RestartGame;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    void Update()
    {
        if (!model.IsPlaying)
            return;
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        if (model.spawnedEnemies == model.targetEnemies)
            return;
        if (Time.time >= model.nextSpawnEnemyTime)
        {
            SpawnEnemy();
            model.nextSpawnEnemyTime = Time.time + Random.Range(settings.minEnemySpawnDelay, settings.maxEnemySpawnDelay);
            model.spawnedEnemies++;
        }
    }
    
    private void SpawnEnemy()
    {
        var point = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)];
        var enemy = enemyFactory.GetEnemyInstance(EnemyType.Simple, point);
        enemy.Initialize(settings);
        enemy.model.OnDeath += OnEnemyDeath;
        enemy.model.onPlayerDamage += playerView.model.AddDamage;
        activeEnemies.Add(enemy);
    }

    private void OnEnemyDeath()
    {
        if (model.state == GameModel.GameState.GameOver)
            return;
        model.killedEnemies++;
        if (model.targetEnemies == model.killedEnemies)
        {
            EndGame(true);
        }
    }
    
    private void OnPlayerHealthChanged(int health)
    {
        if (model.state == GameModel.GameState.GameOver)
            return;
        ui.UpdatePlayerHealth(health);
        if (health == 0)
        {
            EndGame(false);
        }
    }

    private void EndGame(bool complete)
    {
        model.state = GameModel.GameState.GameOver;
        foreach (var enemy in activeEnemies)
        {
            enemy.Destroy();
        }
        if (complete)
            ui.gameCompletePanel.Show();
        else
            ui.gameOverPanel.Show();
    }
}
