﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//justin

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
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
    public void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        //enable the scripts again
    }
    public void ReturnToMainMenu()
    {
        GameObject player = GameObject.Find("Player");
        Destroy(player);
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        SceneManager.LoadScene(0);
    }
    public void RestartLevel(){
        GameObject player = GameObject.Find("Player");
        Destroy(player);
        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
