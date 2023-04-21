using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{

    [SerializeField] private BeeCondition _beeCondition;
    
    public void BackHomeButton()
    {
        Time.timeScale = 1;
        _beeCondition.gameOverPanel.transform.DOScale(Vector3.zero, .1f).OnComplete(() =>
            SceneManager.LoadScene("MainScene"));

    }
    
    public void StartGame()
    {
        Time.timeScale = 1;
        _beeCondition.startPanel.transform.DOScale(Vector3.zero, .3f).OnComplete(() =>
            _beeCondition.startPanel.SetActive(false));

    }
    
}
