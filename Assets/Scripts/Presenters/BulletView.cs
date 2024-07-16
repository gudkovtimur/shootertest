using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletView : BaseView
{

    public Bullet model;

    public void Initialize(float moveSpeed, int damage, Vector2 targetPoint)
    {
        model = new Bullet
        {
            body = GetComponent<Rigidbody2D>(),
            moveSpeed = moveSpeed,
            damage = damage,
        };
        model.moveDirection = (targetPoint - model.body.position).normalized;
        model.active = true;
    }
    
    void FixedUpdate()
    {
        if (!model.active)
            return;
        Move();
        if (!model.InBounds(CameraHelper.OrthographicBounds(Camera.main)))
            Destroy();
    }

    private void Move()
    {
        Vector2 nextPosition = model.body.position + model.moveDirection * model.moveSpeed * Time.fixedDeltaTime;
        model.body.MovePosition(nextPosition);
    }

    public void Destroy()
    {
        model.active = false;
        Destroy(gameObject);
    }

    
}
