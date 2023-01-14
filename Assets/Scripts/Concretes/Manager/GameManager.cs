using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    private void OnEnable()
    {
        CoreSignals.Instance.onGameBegin += GameBegin;
        CoreSignals.Instance.onGameRestart += OnGameRestart;
    }
    private void OnDisable()
    {
        CoreSignals.Instance.onGameBegin -= GameBegin;
        CoreSignals.Instance.onGameRestart -= OnGameRestart;
    }
    private void GameBegin()
    {
        FindObjectOfType<AudioManager>().Play("GameMusic");
    }

    private void OnGameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
