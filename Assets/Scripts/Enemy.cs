using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float Health;
    [SerializeField] private float _changeHealthValue;

    public void OnHeal()
    {
        Health += _changeHealthValue;
    }

    public void OnDamage()
    {
        Health -= _changeHealthValue;
    }
}
