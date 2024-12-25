using DefaultNamespace;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ScorePlayer : MonoBehaviour
{
    [SerializeField] private Text currentScoreText;

    [SerializeField] private Text recordScoreText;

    private PlayerStats stats;

    private int currentScore;

    private int recordScore;

    private void Start()
    {
        stats = new PlayerStats();

        currentScore = 0;

        currentScoreText.text = currentScore.ToString();
    }

    private void Update()
    {
        if (currentScore > recordScore)
        {
            stats.playerRecord = currentScore;

            recordScoreText.text = stats.playerRecord.ToString();

            WriteStatistics();
        }
    }

    private void WriteStatistics()
    {
        var jsonString = JsonUtility.ToJson(stats);
    }

    private void OnEnable()
    {
        EventController.onRecord += Score;
    }

    private void OnDisable()
    {
        EventController.onRecord -= Score;
    }

    public void Score()
    {
        currentScore++;

        currentScoreText.text = currentScore.ToString();
    }
}
