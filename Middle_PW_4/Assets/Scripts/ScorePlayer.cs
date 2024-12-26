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

    private string fileJsonName = "PlayerStats.json";

    private PlayerStats stats;

    private int currentScore;

    private int recordScore;

    private string fileId = "577065746112-3aqbct0nakp3k1c89kvh6b23qkft8lnn.apps.googleusercontent.com";


    private void OnEnable()
    {
        EventController.onRecord += Score;
    }

    private void OnDisable()
    {
        EventController.onRecord -= Score;
    }

    private void Start()
    {
        stats = new PlayerStats();

        ReadStatistics();

        recordScore = stats.playerRecord;

        currentScoreText.text = "0";

        recordScoreText.text = recordScore.ToString();
    }

    private void Update()
    {
        if (currentScore > recordScore)
        {
            stats.playerRecord = currentScore;

            recordScoreText.text = currentScore.ToString();

            WriteStatistics();
        }
    }

    /// <summary>
    /// ������ � ���� json
    /// </summary>
    private void WriteStatistics()
    {
        // ����������� ������ � ������ json
        var jsonString = JsonUtility.ToJson(stats);

        // �������� ���� � �����, ��� ����� ��������� �����
        string filePath = Path.Combine(Application.persistentDataPath, fileJsonName);

        // ������ � ����
        File.WriteAllText(filePath, jsonString);

        Debug.Log("������ ��������� � ����: " + filePath);
    }

    /// <summary>
    /// ������ �� �����
    /// </summary>
    private void ReadStatistics()
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileJsonName);

        // ���� ���� ����������
        if (File.Exists(filePath))
        {
            // ������ ���������� �����
            string jsonString = File.ReadAllText(filePath);

            // ����������� JSON � ������
            //PlayerData loadedData = JsonUtility.FromJson<PlayerData>(jsonString);
            stats = JsonUtility.FromJson<PlayerStats>(jsonString);

            // ������� ����������� ������            
            Debug.Log($"������: {stats.playerRecord}");            
        }
        else
        {
            Debug.LogError("���� �� ������!");
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
}
