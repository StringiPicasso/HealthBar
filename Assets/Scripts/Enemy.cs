using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _changeHealthValue;
    
    public event UnityAction ChangingHealth;

    public float Health => _health;

    public void OnHeal()
    {
        _health += _changeHealthValue;
        ChangingHealth.Invoke();
    }

    public void OnDamage()
    {
        _health -= _changeHealthValue;
        ChangingHealth.Invoke();
    }
}
