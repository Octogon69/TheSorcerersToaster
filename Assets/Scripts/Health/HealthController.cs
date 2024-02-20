using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{

    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _maxHealth;

   public float RemaingHealthPercentage
    {
        get
        {
            return _currentHealth / _maxHealth;
        }
    }

    public bool IsInvincible { get; set; }

    public UnityEvent OnDie;

    public UnityEvent OnDamaged;

    public UnityEvent OnHealthChange;

    public UnityEvent OnEnemyHit;

    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth == 0)
        {
            return;
        }

        if (IsInvincible)
        {
            return;
        }

        _currentHealth -= damageAmount;

        OnHealthChange.Invoke();

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        if (_currentHealth == 0)
        {
            OnDie.Invoke();
            OnEnemyHit.Invoke();
        }
        else
        {
            OnDamaged.Invoke();
        }


        
    }



    public void AddHealth(float amountToAdd)
    {
        if (_currentHealth == _maxHealth)
        {
            return;
        }

        _currentHealth += amountToAdd;

        OnHealthChange.Invoke();

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }


}
