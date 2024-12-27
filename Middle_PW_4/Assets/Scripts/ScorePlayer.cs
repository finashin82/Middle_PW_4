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
        // ���� ���� json �� ����������, �� ������� ����
        if (!File.Exists(LocalJson.filePath))
        {
            LocalJson.CreateJsonFile();

            Debug.Log("���� ������: " + LocalJson.filePath);
        }
        else
        {
            Debug.Log("���� ��� ����������.");
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
    /// ������� ����
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
