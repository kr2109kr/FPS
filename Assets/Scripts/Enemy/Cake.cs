using UnityEngine;

public class Cake : Enemy
{
    void Start()
    {
        base.currentHealth = base.maxHealth;
    }

    
}
