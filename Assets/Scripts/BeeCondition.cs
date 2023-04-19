using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BeeCondition : MonoBehaviour
{
    public float breath;
    private bool isinhale;
    public bool isinGas;
    
    public float fillSpeed = 0.1f;
    public Color startColor = Color.blue;
    public Color endColor = Color.red;
    
    [SerializeField] private float maxbreath = 1;
    
    public float beeHealth;
    [SerializeField] private float maxhealth = 100;
    [SerializeField] private BarConditions _BarConditions;

   
    void Start()
    {
        beeHealth = maxhealth;
       
    }
    //bar 0 dan başlar ve mouse basınca hızlıca yükselir hüüp diye ses çıkar
    //100e ulaştığı zaman -=1 ile azaltırsın nefes sıfır olduğunda hala gaz geliyorsa can azalır
    
    
    public void isInhale(bool _isinhale)
    {
        isinhale = _isinhale;
    }

    IEnumerator DurationHoldbreath()
    {
        
        yield return new WaitForSeconds(3);
        
    }
    void Update()
    {
        _BarConditions.UpdateHealthBar(maxhealth,beeHealth);
        _BarConditions.UpdateBreathBar(maxbreath,breath);

        if (isinhale == true && isinGas == false)
        {
            breath += 0.3f*Time.deltaTime;
            
            //breath += fillSpeed * Time.deltaTime;
            //breath = Mathf.Clamp01(breath);
            breath = Mathf.Clamp(breath,0f,100f);
            _BarConditions.breathbarSprite.fillAmount = breath;
           
            _BarConditions.breathbarSprite.color = Color.Lerp(startColor, endColor,breath);
        }
        else
        {
            breath -= 0.1f;
            //_BarConditions.breathbarSprite.color = Color.Lerp(endColor, startColor,breath*Time.deltaTime*20f);
        }

        if (breath <= 0 ) breath = 0;

        if (breath >= 100 ) breath = 100;
        
        
        if(beeHealth <= 0f)
        {
            SceneManager.LoadScene(0);
        }
    }
}
