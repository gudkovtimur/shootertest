using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    
    public float fireRange;
    public float fireRate;
    public int damage;
    public float bulletSpeed;
    public List<EnemyView> activeEnemies;
    public EnemyView target;
    public float lastFireTime;

    private float minPositionX, maxPositionX, minPositionY, maxPositionY;

    public void InitMoveArea(SpriteRenderer playerRenderer, SpriteRenderer finishRender)
    {
        var cameraBounds = CameraHelper.OrthographicBounds(Camera.main);
        var size = playerRenderer.bounds.size;
        minPositionX = cameraBounds.min.x + size.x/2f;
        minPositionY = cameraBounds.min.y + size.y/2f;
        maxPositionX = cameraBounds.max.x - size.x/2f;
        maxPositionY = finishRender.bounds.min.y - size.y/2f;
    }

    public Vector2 ClampPositionInMoveArea(Vector2 position)
    {
        position.x = Mathf.Clamp(position.x, minPositionX, maxPositionX);
        position.y = Mathf.Clamp(position.y, minPositionY, maxPositionY);
        return position;
    }

    public void UpdateNearTarget()
    {
        if (target && Vector2.Distance(target.model.position, position) > fireRange)
        {
            target = null;
        }

        for (int i = activeEnemies.Count - 1; i >= 0; i--)
        {
            var enemy = activeEnemies[i];
            if (enemy == null || !enemy.model.IsAlive)
            {
                activeEnemies.RemoveAt(i);
                continue;
            }
            if (Vector2.Distance(enemy.model.position, position) <= fireRange)
            {
                target = enemy;
            }
        }
    }

    public bool CanShoot()
    {
        return Time.time - lastFireTime >= fireRate;
    }
    
}
