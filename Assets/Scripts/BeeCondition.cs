using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class BeeCondition : MonoBehaviour
{
    public float breath;
    private bool isinhale;
    public bool isinGas;
    public GameObject button;
    public float fillSpeed = 0.1f;
    public Color startColor = Color.blue;
    public Color endColor = Color.red;

    public Image damageFade;
    
    public Color startColorhealth;
    public Color endColorhealth;
    
    [SerializeField] private float maxbreath = 1;
    
    public float beeHealth;
    [SerializeField] private float maxhealth = 100;
    [SerializeField] private BarConditions _BarConditions;

   
    void Start()
    {
        damageFade.enabled = false;
        beeHealth = maxhealth;
        
       
    }
    //bar 0 dan başlar ve mouse basınca hızlıca yükselir hüüp diye ses çıkar
    //100e ulaştığı zaman -=1 ile azaltırsın nefes sıfır olduğunda hala gaz geliyorsa can azalır
    
    
    public void isInhale(bool _isinhale)
    {
        isinhale = _isinhale;
    }
//eğer 3 saniye 100de nefes tutarsan buton deactive kalır.
    IEnumerator DurationHoldbreath()
    {
        button.SetActive(false);
        Debug.Log("1");
        yield return new WaitForSeconds(3);
        button.SetActive(true);
        Debug.Log("2");
    }
    void Update()
    {
        _BarConditions.UpdateHealthBar(maxhealth,beeHealth);
        

        if (isinhale == true && isinGas == false)
        {
            breath += 20f*Time.deltaTime;
            breath = Mathf.Clamp(breath,0f,maxbreath);
            float fillAmount = breath / 100f;
            _BarConditions.UpdateBreathBar(maxbreath,breath);
            _BarConditions.breathbarSprite.color = Color.Lerp(startColor, endColor,fillAmount * fillAmount);
        }
        else
        {
            breath -= 10f * Time.deltaTime;
            breath = Mathf.Clamp(breath, 0f, maxbreath);
            float fillAmount = breath / 100f;
            _BarConditions.breathbarSprite.fillAmount = fillAmount;
            _BarConditions.breathbarSprite.color = Color.Lerp(startColor, endColor, fillAmount);
            
           
        }

        if (breath <= 0 ) breath = 0;

        if (breath >= 100)
        {
            StartCoroutine(DurationHoldbreath());
            breath = 100;
        }
        
        if(beeHealth <= 40f)
        {
            damageFade.enabled = true;
            damageFade.color = Color.Lerp(startColorhealth, endColorhealth, Mathf.PingPong(Time.time*3,1));
        }
        
        if(beeHealth <= 0f)
        {
            SceneManager.LoadScene(0);
        }
    }
}
