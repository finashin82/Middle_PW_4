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
    /// ������ � ���� json
    /// </summary>
    public static void WriteStatistics()
    {
        // ����������� ������ � ������ json
        var jsonString = JsonUtility.ToJson(stats);

        // ������ � ����
        File.WriteAllText(filePath, jsonString);

        Debug.Log("������ ��������� � ����: " + filePath);
    }

    /// <summary>
    /// ������ �� �����
    /// </summary>
    public static void ReadStatistics()
    {
        // ���� ���� ����������
        if (File.Exists(filePath))
        {
            // ������ ���������� �����
            string jsonString = File.ReadAllText(filePath);

            // ����������� JSON � ������            
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
    /// �������� ����� Json
    /// </summary>
    public static void DelFileJson()
    {
        if (File.Exists(filePath))
        {
            // �������� �����
            File.Delete(filePath);

            Debug.Log("���� ������� ������.");
        }
        else
        {
            Debug.LogWarning("����� �� ����������.");
        }
    }

    /// <summary>
    /// �������� ����� Json
    /// </summary>
    public static void CreateJsonFile()
    {
        // ������� ������ JSON ������
        string jsonData = "{}"; // ��� ����� ������ ��������

        // ������ ������ � ����
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.Write(jsonData);
        }

        Debug.Log($"������ ����� ���� {filePath}.");
    }
}
