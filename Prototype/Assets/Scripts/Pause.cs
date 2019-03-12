using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    void Start()
    {
        pausePanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
                PauseGame();
            //if (pausePanel.activeInHierarchy)
            //{
            //    ContinueGame();
           // }
        }
    }
    private void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    private void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        //enable the scripts again
    }
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
