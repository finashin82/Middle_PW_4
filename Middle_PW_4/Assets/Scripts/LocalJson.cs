using DefaultNamespace;
using System.IO;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public static class LocalJson
{
    public static PlayerStats stats;

    public static string fileJsonName = "PlayerStats.json";

    public static string filePath = Path.Combine(Application.persistentDataPath, fileJsonName);

    /// <summary>
    /// Запись в файл json
    /// </summary>
    public static void WriteStatistics()
    {
        // Преобразуем данные в строку json
        var jsonString = JsonUtility.ToJson(stats);

        // Запись в файл
        File.WriteAllText(filePath, jsonString);

        Debug.Log("Данные сохранены в файл: " + filePath);
    }

    /// <summary>
    /// Чтение из файла
    /// </summary>
    public static void ReadStatistics()
    {
        // Если файл существует
        if (File.Exists(filePath))
        {
            // Читаем содержимое файла
            string jsonString = File.ReadAllText(filePath);

            // Преобразуем JSON в объект            
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
    /// Удаление файла Json
    /// </summary>
    public static void DelFileJson()
    {
        if (File.Exists(filePath))
        {
            // Удаление файла
            File.Delete(filePath);

            Debug.Log("Файл успешно удален.");
        }
        else
        {
            Debug.LogWarning("Файла не существует.");
        }
    }

    /// <summary>
    /// Создание файла Json
    /// </summary>
    public static void CreateJsonFile()
    {
        // Создаем пустой JSON объект
        string jsonData = "{}"; // Это будет пустым объектом

        // Запись данных в файл
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.Write(jsonData);
        }

        Debug.Log($"Создан новый файл {filePath}.");
    }
}
