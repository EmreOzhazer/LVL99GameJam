using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BeeCondition : MonoBehaviour
{
    
    public float beeHealth;
    
    [SerializeField] private float maxhealth = 100;
    [SerializeField] private HealthBar _healthBar;

   // [SerializeField] private SprayController _sprayController;
    // Start is called before the first frame update
    void Start()
    {
        beeHealth = maxhealth;
        
       
    }

    // Update is called once per frame
    void Update()
    {
        _healthBar.UpdateHealthBar(maxhealth,beeHealth);
        
        if(beeHealth <= 0f)
        {
            SceneManager.LoadScene(0);
        }
    }
}
