using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    float maxHealth = 100.0F;

    float _currentHealth;

    private void Awake()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= Mathf.Abs(damage);
        if(_currentHealth <= 0.0F )
        {
            Destroy(gameObject);
        }
    }

    public void Heal(float repair)
    {
        _currentHealth += Mathf.Abs(repair);
    }
}
