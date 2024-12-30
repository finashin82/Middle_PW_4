using NUnit.Framework.Interfaces;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class GoogleSheetDataReader
{  
    // ����� ��� ������ CSV-����� � �������� ������ �������� ItemData
    public static List<GoogleSheetData> ReadCsv(string filePathCsv, string fileNameCsv)
    {
        filePathCsv = Path.Combine(filePathCsv, fileNameCsv);

        var itemDatas = new List<GoogleSheetData>();

        // �������� �� ������� �����
        if (!File.Exists(filePathCsv))
        {
            Debug.LogError($"���� {filePathCsv} �� ������.");
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
                    Debug.LogWarning("�������� ������ ������ � CSV-�����.");
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
