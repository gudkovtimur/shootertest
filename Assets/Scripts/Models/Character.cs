using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character
{

    public UnityAction<int> OnHealthChanged;
    public UnityAction OnDeath;
    
    public bool active;
    public int health;

    public float moveSpeed;
    public Rigidbody2D body;

    public void InitHealth(int health)
    {
        this.health = health;
        OnHealthChanged?.Invoke(health);
    }
    
    public void AddDamage(int damage)
    {
        health = Mathf.Max(0, health - damage);
        OnHealthChanged?.Invoke(health);
        if (health == 0)
            OnDeath?.Invoke();
    }
    
    public bool IsAlive => health > 0;

    public Vector2 position => body.position;

}
