using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyView : BaseView
{

    public Enemy model;

    public void Initialize(GameSettings settings)
    {
        float moveSpeed = Random.Range(settings.minEnemySpeed, settings.maxEnemySpeed);
        model = new Enemy
        {
            body = GetComponent<Rigidbody2D>(),
            health = settings.enemyHealth,
            moveSpeed = moveSpeed,
            active = true
        };
        model.OnDeath += Destroy;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!model.active || !model.IsAlive)
            return;
        Move();
    }

    private void Move()
    {
        Vector2 nextPosition = model.body.position + Vector2.down * model.moveSpeed * Time.fixedDeltaTime;
        model.body.MovePosition(nextPosition);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBullet")
        {
            var bullet = other.GetComponent<BulletView>();
            model.AddDamage(bullet.model.damage);
            bullet.Destroy();
        }
        else if (other.tag == "Finish")
        {
            model.onPlayerDamage?.Invoke(1);
            model.OnDeath?.Invoke();
            Destroy();
        }
    }

    public void Destroy()
    {
        model.active = false;
        Destroy(gameObject);
    }
    
}
