using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;

    [SerializeField] private Slider slider;


    private void Awake()
    {
        slider.maxValue = maxHealth;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        slider.value = currentHealth;
    }


    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
        slider.value = currentHealth;
    }


    private void Die()
    {
        GameManager.Instance.GameOver();
    }
}
