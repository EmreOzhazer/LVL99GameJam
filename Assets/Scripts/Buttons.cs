using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    [SerializeField] private AudioSource beeflySound;
    [SerializeField] private AudioSource clickSound;
    [SerializeField] private BeeCondition _beeCondition;
    
    public void BackHomeButton()
    {
        Time.timeScale = 1;
        clickSound.Play();
        _beeCondition.gameOverPanel.transform.DOScale(Vector3.zero, .1f).OnComplete(() =>
            SceneManager.LoadScene("MainScene"));

    }
    
    public void StartGame()
    {
        beeflySound.Play();
        clickSound.Play();
        Time.timeScale = 1;
        _beeCondition.startPanel.transform.DOScale(Vector3.zero, .3f).OnComplete(() =>
            _beeCondition.startPanel.SetActive(false));

    }
    
}
