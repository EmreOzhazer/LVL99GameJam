using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class BarConditions : MonoBehaviour
{
    // [SerializeField] private BeeCondition _beeCondition;
    [SerializeField] public Image breathbarSprite;
    [SerializeField] public Image healtbarSprite;

    public void UpdateHealthBar(float maxHealth ,float currentHealth)
    {
        healtbarSprite.fillAmount = currentHealth / maxHealth;
    }
    public void UpdateBreathBar(float maxbreath ,float currentbreath)
    {
        breathbarSprite.fillAmount = currentbreath / maxbreath;
    }
}
