using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerView : BaseView
{
    
    public SpriteRenderer playerRenderer;
    public BulletView bulletPrefab;
    public Transform bulletPoint;
    
    public Player model;

    public void Initialize(GameSettings settings, SpriteRenderer finishRenderer, ref List<EnemyView> activeEnemies, UnityAction<int> onHealthChanged)
    {
        model = new Player
        {
            body = GetComponent<Rigidbody2D>(),
            health = settings.playerHealth,
            damage = settings.playerDamage,
            fireRange = settings.playerFireRange,
            fireRate = settings.playerFireRate,
            activeEnemies = activeEnemies,
            bulletSpeed = settings.playerBulletSpeed,
            moveSpeed = settings.playerMoveSpeed
        };
        model.OnHealthChanged += onHealthChanged;
        model.InitHealth(settings.playerHealth);
        model.InitMoveArea(playerRenderer, finishRenderer);
        model.active = true;
    }
    
    public void SetActive(bool active)
    {
        model.active = active;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!model.active || !model.IsAlive)
            return;
        ProcessInput();
        ProcessFire();
    }

    private void ProcessInput()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 nextPosition = model.body.position + input.normalized * 10f * Time.fixedDeltaTime;
        nextPosition = model.ClampPositionInMoveArea(nextPosition);
        model.body.MovePosition(nextPosition);
    }

    private void ProcessFire()
    {
        model.UpdateNearTarget();
        if (model.target && model.CanShoot())
        {
            SpawnBullet();
            model.lastFireTime = Time.time;
        }
    }

    private void SpawnBullet()
    {
        var bullet = Instantiate(bulletPrefab, bulletPoint.position, Quaternion.identity);
        bullet.Initialize(model.bulletSpeed, model.damage, model.target.model.position);
    }


}
