using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet
{

    public bool active;
    public Rigidbody2D body;
    public float moveSpeed;
    public int damage;
    public Vector2 moveDirection;

    public bool InBounds(Bounds bounds)
    {
        return bounds.min.x < body.position.x && body.position.x < bounds.max.x &&
               bounds.min.y < body.position.y && body.position.y < bounds.max.y;
    }

}
