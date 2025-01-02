using System;
using System.IO;
using App.Code.MVVM.Models;
using UnityEngine;

namespace App.Code.MVVM
{
    public class JsonHandler
    {
        private readonly string filePath = Path.Combine(Application.persistentDataPath, "Archive.json");

        public ArchiveModel ArchiveInit()
        {
            var archive = !File.Exists(filePath) ? new ArchiveModel() : LoadFromJson();

            return archive;
        }
        
        public void SaveToJson(ArchiveModel data)
        {
            try
            {
                var json = JsonUtility.ToJson(data, true);
                File.WriteAllText(filePath, json);
                Debug.Log("Data saved successfully: " + filePath);
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to save data: " + e.Message);
            }
        }

        private ArchiveModel LoadFromJson()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var json = File.ReadAllText(filePath);
                    var data = JsonUtility.FromJson<ArchiveModel>(json);
                    Debug.Log("Data loaded from JSON");
                    return data;
                }

                Debug.LogWarning("File is not found: " + filePath);
                return null;
            }
            catch (Exception e)
            {
                Debug.LogError("Something went wrong: " + e.Message);
                return null;
            }
        }
    }
}
