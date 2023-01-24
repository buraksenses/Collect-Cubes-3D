using System.IO;
using UnityEngine;

namespace CollectCubes.Managers
{
    public class GameSaveManager : Singleton<GameSaveManager>
    {
        [SerializeField] private DataManager gameData;
        
        private void Start()
        {
            LoadGame();
        }

        private bool IsSaveFile()
        {
            return Directory.Exists(Application.persistentDataPath + "collectcubes_save");
        }
    
        internal void SaveGame()
        {
            if (!IsSaveFile())
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/collectcubes_save");
            }
            if (!Directory.Exists(Application.persistentDataPath + "/collectcubes_save/collectcubes_data"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/collectcubes_save/collectcubes_data");
            }
            var json = JsonUtility.ToJson(gameData);
            File.WriteAllText(Application.persistentDataPath + "/collectcubes_save/collectcubes_data/collectcubes_save.txt", json);
        }
    
        private void LoadGame()
        {
            if (!Directory.Exists(Application.persistentDataPath + "/collectcubes_save/collectcubes_data"))
            {
                SaveGame();
            }
    
            if (File.Exists(Application.persistentDataPath + "/collectcubes_save/collectcubes_data/collectcubes_save.txt"))
            {
                var file = File.ReadAllText(Application.persistentDataPath + "/collectcubes_save/collectcubes_data/collectcubes_save.txt");
                JsonUtility.FromJsonOverwrite((string)file, gameData);
            }
        }
    }
}


