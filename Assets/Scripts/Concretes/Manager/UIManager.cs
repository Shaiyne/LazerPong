using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] protected internal Button jumpButton;
    [SerializeField] protected internal Button startButton;
    [SerializeField] TextMeshProUGUI startCountdown;
    [SerializeField] protected internal Image PointImage;
    [SerializeField] protected internal GameObject GameEnded;
    [SerializeField] protected internal TextMeshProUGUI MaxScoreText;
    UIController uIController;
    protected internal ScoreSaveData scoreSave = new ScoreSaveData();
    private void Awake()
    {
        uIController = GetComponent<UIController>();
    }

    private void OnEnable()
    {
        UISignals.Instance.onScorePoint += OnScorePoint;
        CoreSignals.Instance.onGameEnded += OnGameEnded;
    }
    private void OnDisable()
    {
        UISignals.Instance.onScorePoint -= OnScorePoint;
        CoreSignals.Instance.onGameEnded -= OnGameEnded;
    }
    public void JumpButton()
    {
        if (jumpButton.enabled)
        {
            uIController.Jumpbutton();
            PlayerSignals.Instance.onJumpAction?.Invoke();
        }

    }
    public void GameStartButton()
    {
        //CoreSignals.Instance.onGameBegin?.Invoke();
        uIController.SetGameObjectActiviness(startButton.transform.gameObject, false);
        uIController.SetGameObjectActiviness(startCountdown.transform.gameObject, true);
        uIController.SetGameObjectActiviness(jumpButton.transform.gameObject, true);
        uIController.SetGameObjectActiviness(PointImage.transform.gameObject, true);
    }

    public void OnScorePoint()
    {
        uIController.ScorePoint();
    }

    private void OnGameEnded()
    {
        uIController.SetGameObjectActiviness(GameEnded, true);
        uIController.SetGameObjectActiviness(jumpButton.transform.gameObject, false);
        uIController.GameEnded();
        uIController.MaxScore();
    }
    public void TryAgainButton()
    {
        CoreSignals.Instance.onGameRestart.Invoke();
    }
}
