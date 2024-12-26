using DefaultNamespace;
using System;
using System.IO;
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

            recordScoreText.text = recordScore.ToString();

            WriteStatistics();
        }
    }

    /// <summary>
    /// Запись в файл json
    /// </summary>
    private void WriteStatistics()
    {
        // Преобразуем данные в строку json
        var jsonString = JsonUtility.ToJson(stats);

        // Получаем путь к папке, где можно сохранять файлы
        string filePath = Path.Combine(Application.persistentDataPath, fileJsonName);

        // Запись в файл
        File.WriteAllText(filePath, jsonString);

        Debug.Log("Данные сохранены в файл: " + filePath);
    }

    /// <summary>
    /// Чтение из файла
    /// </summary>
    private void ReadStatistics()
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileJsonName);

        // Если файл существует
        if (File.Exists(filePath))
        {
            // Читаем содержимое файла
            string jsonString = File.ReadAllText(filePath);

            // Преобразуем JSON в объект
            //PlayerData loadedData = JsonUtility.FromJson<PlayerData>(jsonString);
            stats = JsonUtility.FromJson<PlayerStats>(jsonString);

            // Выводим загруженные данные            
            Debug.Log($"Рекорд: {stats.playerRecord}");            
        }
        else
        {
            Debug.LogError("Файл не найден!");
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
}
