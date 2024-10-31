using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private EntityHealth _playerHealth;

    private void Start()
    {
        CachedMaxHealth = _playerHealth.MaxHealth;
        _slider.maxValue = CachedMaxHealth;
        UpdateSlider(_playerHealth.CurrentHealth, _playerHealth.MaxHealth);

        _playerHealth.OnHealthChanged.AddListener(UpdateSlider);
    }

    private int CachedMaxHealth { get; set; }

    private void UpdateSlider(int currentHealth, int maxHealth)
    {
        _slider.maxValue = maxHealth;
        _slider.value = currentHealth;
        _text.text = $"{currentHealth} / {maxHealth}";
    }
}

