using NUnit.Framework.Interfaces;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class GoogleSheetDataReader
{  
    // Метод для чтения CSV-файла и возврата списка объектов ItemData
    public static List<GoogleSheetData> ReadCsv(string filePathCsv, string fileNameCsv)
    {
        filePathCsv = Path.Combine(filePathCsv, fileNameCsv);

        var itemDatas = new List<GoogleSheetData>();

        // Проверка на наличие файла
        if (!File.Exists(filePathCsv))
        {
            Debug.LogError($"Файл {filePathCsv} не найден.");
            return null;
        }

        using (var reader = new StreamReader(filePathCsv))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                if (values.Length != 2)
                {
                    Debug.LogWarning("Неверный формат строки в CSV-файле.");
                    continue;
                }

                var name = values[0];
                var value = values[1];

                itemDatas.Add(new GoogleSheetData { Name = name, Value = value });
            }
        }

        return itemDatas;
    }
}
