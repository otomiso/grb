using System.IO;
using UnityEngine;

[System.Serializable]
public class DataToSave
{
    public string name;
    public int HP;

    public DataToSave(string name, int HP)
    {
        this.name = name;
        this.HP = HP;
    }
}

public class jsonWritter : MonoBehaviour
{
    private string filePath;

    void Start()
    {
        // 保存先のファイルパスを指定
        filePath = Application.dataPath + "/characterJson/character.json";

        // サンプルデータの保存と読み込み
        SaveJsonData(new DataToSave("仮太郎", 175));
        LoadJsonData();
    }

    void SaveJsonData(DataToSave data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json); // JSONデータを書き込み
        Debug.Log($"データ保存完了: {filePath}");
    }

    void LoadJsonData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath); // JSONデータを読み込み
            DataToSave loadedData = JsonUtility.FromJson<DataToSave>(json);
            Debug.Log($"データ読み込み完了: 名前={loadedData.name}, HP={loadedData.HP}");
        }
        else
        {
            Debug.LogWarning("保存ファイルが見つかりませんでした！");
        }
    }
}