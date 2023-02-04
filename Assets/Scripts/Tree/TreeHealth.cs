using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHealth
{

    private int maxHealth;
    public int MaxHealth => maxHealth;

    private int health;
    public int Health
    {
        get => health;
        set
        {
            health = Mathf.Clamp(value, 0, maxHealth);
            onHealthChanged?.Invoke(health);
        }
    }
    public delegate void OnHealthChanged(int health);
    public event OnHealthChanged onHealthChanged;

    public TreeHealth(int maxHealth = 100)
    {
        this.maxHealth = maxHealth;
        health = maxHealth;
    }
}
