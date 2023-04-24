using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BeeCondition : MonoBehaviour
{
    [SerializeField] private AudioSource collectSound;
    [SerializeField] private AudioSource failSound;
    [SerializeField] private AudioSource winSound;
    
    public float breath;
    private bool isinhale;
    public bool isDead;
    public bool isinGas;
    public GameObject button;//3 kere nefes tutabilsin 
    private float fillAmount;
    public int breathLeft;
    public Image[] breathLeftAmount;
    private int activeImageIndex = 0;
    
    public GameObject gameOverPanel;
    public GameObject startPanel;
    public GameObject winPanel;
    
    public TextMeshProUGUI foodText;
    private int foodAmount;
   
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
        
        Time.timeScale = 0;
        damageFade.enabled = false;
        beeHealth = maxhealth;

    }
    //bar 0 dan başlar ve mouse basınca hızlıca yükselir hüüp diye ses çıkar
    //100e ulaştığı zaman -=1 ile azaltırsın nefes sıfır olduğunda hala gaz geliyorsa can azalır
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            collectSound.Play();
            foodAmount++;
            foodText.text = foodAmount+"/4";
            Destroy(other.gameObject);
            if (foodAmount == 4)
            {
                winSound.Play();
                winPanel.SetActive(true);
            
            }
        }
    }

    public void isInhale(bool _isinhale)
    {
        isinhale = _isinhale;
    }

    public void BreathLeft()
    {
        breathLeftAmount[activeImageIndex].enabled = false;
        activeImageIndex++;
        breathLeft-=1;
        
    }
    IEnumerator onDie()
    {
        
        
        yield return new WaitForSeconds(3);
            
            
            
    }
    public void ClickBreath()
    {
        isinhale = true;
        
        StartCoroutine(DurationHoldbreath());
        
        IEnumerator DurationHoldbreath()
        {
            if (!isinGas)
            {
                
                breath += 80f*Time.deltaTime;
                breath = Mathf.Clamp(breath,0f,maxbreath);
                fillAmount = breath / 100f;
                _BarConditions.UpdateBreathBar(maxbreath,breath);
                _BarConditions.breathbarSprite.color = Color.Lerp(startColor, endColor,fillAmount * fillAmount);
            }

            yield return new WaitForSeconds(3);
            
            
            
        }
        
    }
//eğer 3 saniye 100de nefes tutarsan buton deactive kalır.
//butona 1 kere basınca full yüklenir sonra yavaşca iner aşağı 3 hakkı var
   
    void Update()
    {
        _BarConditions.UpdateHealthBar(maxhealth,beeHealth);
        
    
        if (isinhale == true && isinGas == false)
        {
            ClickBreath();
        }
        else
        {
            breath -= 20f * Time.deltaTime;
            breath = Mathf.Clamp(breath, 0f, maxbreath);
            fillAmount = breath / 100f;
            _BarConditions.breathbarSprite.fillAmount = fillAmount;
            _BarConditions.breathbarSprite.color = Color.Lerp(startColor, endColor, fillAmount);
           
        }

        if (breath <= 0 ) breath = 0;
        if(breathLeft==0) button.gameObject.SetActive(false);
        if (breath >= 100)
        {
            isinhale = false;
            //StartCoroutine(DurationHoldbreath());
            breath = 100;
        }
        
        if(beeHealth <= 40f)
        {
            damageFade.enabled = true;
            damageFade.color = Color.Lerp(startColorhealth, endColorhealth, Mathf.PingPong(Time.time*3,1));
        }
        
        if(beeHealth <= 0f)
        {
            isDead = true;
        }

        
        if (isDead)
        {
            //Time.timeScale = 1;
            gameOverPanel.SetActive(true);
            
            beeHealth = 0.01f;
            failSound.Play();
            isDead = false;
        }
    }
}
