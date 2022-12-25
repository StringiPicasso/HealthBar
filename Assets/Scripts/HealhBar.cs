using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealhBar : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _reducSpeed;

    private Coroutine _activeCoroutine;

    private void OnEnable()
    {
        _enemy.ChangingHealth += OnSliderChanged;
    }

    private void Start()
    {
        _slider.maxValue=_enemy.Health;
        Restart(_slider.maxValue);
    }

    public void OnSliderChanged()
    {
        Restart(_enemy.Health);
    }

    private void Restart(float target)
    {
        if (_activeCoroutine != null)
        {
            StopCoroutine(_activeCoroutine);
        }

        _activeCoroutine = StartCoroutine(ChangeSliderValue(target));
    }

    private IEnumerator ChangeSliderValue(float target)
    {
        while (_slider.value != target)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, _reducSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
