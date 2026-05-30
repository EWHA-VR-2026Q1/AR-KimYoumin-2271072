using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class SaveScene : MonoBehaviour
{
    public List<SaveableObject> saveObjects;

    private string savePath;

    private void Awake()
    {
        savePath = Path.Combine(
            Application.persistentDataPath,
            "saveData.json");
    }

    public void SaveGame()
    {
        WorldData worldData = new WorldData();

        foreach (SaveableObject obj in saveObjects)
        {
            Debug.Log("저장중 : " + obj.name);
            
            TransformData data = new TransformData();

            data.objectName = obj.objectID;

            data.position = obj.transform.position;
            data.rotation = obj.transform.rotation;

            worldData.objects.Add(data);
        }

        string json =
            JsonUtility.ToJson(worldData, true);

        File.WriteAllText(savePath, json);

        Debug.Log("저장 완료");

        
    }

    public void LoadGame()
    {
        if (!File.Exists(savePath))
            return;

        string json =
            File.ReadAllText(savePath);

        WorldData worldData =
            JsonUtility.FromJson<WorldData>(json);

        foreach (TransformData data in worldData.objects)
        {
            SaveableObject target =
                saveObjects.Find(
                    x => x.objectID == data.objectName);

            if (target == null)
                continue;

            target.transform.position =
                data.position;

            target.transform.rotation =
                data.rotation;
        }

        Debug.Log("불러오기 완료");
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}