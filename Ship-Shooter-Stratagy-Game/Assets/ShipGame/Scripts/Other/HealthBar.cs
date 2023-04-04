using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    private ShipManager shipManager;

    [SerializeField] private TextMeshProUGUI healthText;
    private void Awake()
    {
        healthSlider = GetComponent<Slider>();
        shipManager = FindObjectOfType<ShipManager>();
        healthSlider.maxValue = shipManager.shipMaxHealth;
        healthSlider.value = healthSlider.maxValue;
    }
    void Update()
    {
        healthSlider.value= shipManager.shipcurrentHealth;
        healthText.text = shipManager.shipcurrentHealth + "/" + shipManager.shipMaxHealth;
    }
}
