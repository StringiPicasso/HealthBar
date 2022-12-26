using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minHealth;
    
    private float _health;
    
    public event UnityAction<float> OnChangingHealth;

    public float Health => _health;
    public float MaxHealth => _maxHealth;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void TakeHeal(float healValue)
    {
        _health += healValue;
        _health = Mathf.Clamp(_health,_minHealth, _maxHealth);
        OnChangingHealth?.Invoke(Health);
    }

    public void TakeDamage(float damageValue)
    {
        _health -= damageValue;
        _health = Mathf.Clamp(_health, _minHealth, _maxHealth);
        OnChangingHealth?.Invoke(Health);
    }
}
