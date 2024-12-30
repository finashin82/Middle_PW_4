using NReco.Csv;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using ColorUtility = UnityEngine.ColorUtility;

public class GoogleSheetDataUse : MonoBehaviour
{
    [SerializeField] private Image image;

    [SerializeField] private Text text;

    private Color color;

    public static string filePathCsv = "Assets/GoogleSheet";

    public static string fileNameCsv = "GameTableGoogle.csv";

    void Start()
    {
        // ������ ������ �� CSV-�����
        var items = GoogleSheetDataReader.ReadCsv(filePathCsv, fileNameCsv);

        if (items == null || items.Count == 0)
        {
            Debug.LogError("�� ������� ��������� ������ �� CSV-�����.");
            return;
        }

        foreach (var item in items)
        {
            Debug.Log($"�������: {item.Name}, ��������: {item.Value}");
        }

        // ��������� string � Color � ��������� ��� ���������� color
        ColorUtility.TryParseHtmlString(items[0].Value, out color);        

        image.color = color;

        text.text = items[1].Value;
    }
}
