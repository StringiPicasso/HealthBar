using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _changeHealthValue;
    
    public event UnityAction<float> OnChangingHealth;

    public float Health => _health;

    public void OnHeal()
    {
        _health += _changeHealthValue;
        OnChangingHealth?.Invoke(Health);
    }

    public void OnDamage()
    {
        _health -= _changeHealthValue;
        OnChangingHealth?.Invoke(Health);
    }
}
