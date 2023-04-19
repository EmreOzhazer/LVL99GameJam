using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    

    [SerializeField] private Image healtbarSprite;

    public void UpdateHealthBar(float maxHealth ,float currentHealth)
    {
        healtbarSprite.fillAmount = currentHealth / maxHealth;
    }
}
