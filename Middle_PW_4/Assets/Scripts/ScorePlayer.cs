using DefaultNamespace;
using System;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class ScorePlayer : MonoBehaviour
{
    [SerializeField] private Text currentScoreText;

    [SerializeField] private Text recordScoreText;    

    private int currentScore;

    private int recordScore;
    
    private void OnEnable()
    {
        EventController.onScore += Score;
    }

    private void OnDisable()
    {
        EventController.onScore -= Score;
    }

    private void Start()
    {
        // Если файл json не существует, то создать файл
        if (!File.Exists(LocalJson.filePath))
        {
            LocalJson.CreateJsonFile();

            Debug.Log("Файл создан: " + LocalJson.filePath);
        }
        else
        {
            Debug.Log("Файл уже существует.");
        }

        LocalJson.ReadStatistics();

        recordScore = LocalJson.stats.playerRecord;

        currentScoreText.text = "0";

        recordScoreText.text = recordScore.ToString();               
    }

    private void Update()
    {
        if (currentScore > recordScore)
        {
            LocalJson.stats.playerRecord = currentScore;

            recordScoreText.text = currentScore.ToString();

            LocalJson.WriteStatistics();
        }
    }

    /// <summary>
    /// Текущие очки
    /// </summary>
    public void Score()
    {
        currentScore++;

        currentScoreText.text = currentScore.ToString();
    }

    public void ResetRecordJson()
    {
        LocalJson.stats.playerRecord = 0;

        LocalJson.WriteStatistics();
    }
}
