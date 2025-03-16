using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float currentHealth;
    [SerializeField] protected HealthBar healthBar;


    public void TakeDamage(int amount)
    {
        
        currentHealth -= amount;


        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            healthBar.UpdateHealthBar(currentHealth / maxHealth);
        }

        
    }


    protected void Die()
    {
        Destroy(gameObject);
        EnemyManager.Instance.EnemyCountDecrease();
    }


    private IEnumerator healthBarTimer(float duration)
    {
        healthBar.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        healthBar.gameObject.SetActive(false);
    }

}
