using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    public Button restart;
    public Button backHome;
    public Button start;

    [SerializeField] private BeeCondition _beeCondition;
    // Start is called before the first frame update

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        _beeCondition.startPanel.SetActive(false);
       
    }
    public void BackHomeButton()
    {
       
            //update yüzünden heralde
            Time.timeScale = 1;
            Debug.Log("dsadsa");
            _beeCondition.startPanel.SetActive(true);
            _beeCondition.gameOverPanel.SetActive(false);
        
        
        
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        _beeCondition.startPanel.SetActive(false);
    }
    
}
