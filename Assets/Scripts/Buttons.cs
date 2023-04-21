using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{

    [SerializeField] private BeeCondition _beeCondition;
    
    public void BackHomeButton()
    {
        Time.timeScale = 1;
        _beeCondition.startPanel.SetActive(true);
        _beeCondition.gameOverPanel.SetActive(false);
        SceneManager.LoadScene(0);
    }
    
    public void StartGame()
    {
        Time.timeScale = 1;
        _beeCondition.startPanel.SetActive(false);
    }
    
}
