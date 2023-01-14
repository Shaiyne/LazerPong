using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    UIManager uIManager;
    float jumpTimer=0.8f;
    protected internal int scoreCount;
    private void Awake()
    {
        SaveGameManager.LoadGame();
        uIManager = GetComponent<UIManager>();
    }
    protected internal void SetGameObjectActiviness(GameObject go,bool value)
    {
        go.SetActive(value);
    }

    public void Jumpbutton()
    {
        uIManager.jumpButton.enabled = false;
        this.Wait(jumpTimer, () =>
        {
            uIManager.jumpButton.enabled = true;
        });
    }

    public void ScorePoint()
    {
        scoreCount += 1;
        uIManager.PointImage.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = " " +scoreCount ;
        uIManager.scoreSave.ScoreDataInt = scoreCount;
    }
    public void MaxScore()
    {
        SaveGameManager.LoadGame();
        uIManager.MaxScoreText.text = "Max Score :  " + SaveGameManager.CurrentSaveData.ScoreSaveData.ScoreDataInt + " Your Score : " + scoreCount;
    }

    public void GameEnded()
    {
        if (SaveGameManager.CurrentSaveData.ScoreSaveData.ScoreDataInt < uIManager.scoreSave.ScoreDataInt)
        {
            SaveGameManager.CurrentSaveData.ScoreSaveData.ScoreDataInt = uIManager.scoreSave.ScoreDataInt;
            SaveGameManager.SaveGame();
        }

    }
}
