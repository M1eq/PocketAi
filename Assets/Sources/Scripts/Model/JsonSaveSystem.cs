using System.IO;
using UnityEngine;

public class JsonSaveSystem 
{
    public SaveData SaveData => _saveData;

    private string _json;
    private SaveData _saveData = new SaveData();
    private const string SaveDataFileName = "/SaveDataFile.json";

    public void Save()
    {
        _json = JsonUtility.ToJson(_saveData, true);
        File.WriteAllText(Application.persistentDataPath + SaveDataFileName, _json);
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + SaveDataFileName) == false)
            Save();

        _json = File.ReadAllText(Application.persistentDataPath + SaveDataFileName);
        _saveData = JsonUtility.FromJson<SaveData>(_json);
    }
}
