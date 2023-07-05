using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] GameObject menuGO;

    void Start()
    {
        player.Muerte_Player += MenuGameOverOn;
    }

    void MenuGameOverOn(object sender, EventArgs e)
    {
        Time.timeScale = 0;
        menuGO.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}