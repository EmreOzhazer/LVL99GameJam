using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BeeCondition : MonoBehaviour
{
    public float breath;
    private bool isinhale;
    
    [SerializeField] private float maxbreath = 100;
    
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
    
    void Update()
    {
        _BarConditions.UpdateHealthBar(maxhealth,beeHealth);
        _BarConditions.UpdateBreathBar(maxbreath,breath);
        
        if (isinhale == true) breath+=0.3f;
        else
        {
            breath -= 0.1f;
        }
        
        
        if (breath <= 0 )
        {
            breath = 0;
        }
        
        if (breath >= 100 )
        {
            breath = 100;
        }
        
        if(beeHealth <= 0f)
        {
            SceneManager.LoadScene(0);
        }
    }
}
