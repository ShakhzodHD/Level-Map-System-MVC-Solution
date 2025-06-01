using System;
using UnityEngine;

namespace LevelMapModule
{
    public class LevelMapModel : ILevelMapModel
    {
        private const string SAVE_KEY = "LevelMapData";

        public LevelMapData Data { get; private set; }

        public event Action<LevelData> OnLevelUnlocked;
        public event Action<LevelData> OnLevelCompleted;
        public event Action<int> OnCurrentLevelChanged;

        public LevelMapModel()
        {
            Data = new LevelMapData();
        }

        public void CompleteLevel(int levelId, int stars = 0)
        {
            var level = Data.GetLevel(levelId);
            if (level != null)
            {
                bool wasCompleted = level.isCompleted;
                Data.CompleteLevel(levelId, stars);

                if (!wasCompleted)
                {
                    OnLevelCompleted?.Invoke(level);
                }

                UnlockLevel(levelId + 1);

                SaveData();
            }
        }

        public LevelData GetLevel(int levelId)
        {
            return Data.GetLevel(levelId);
        }

        public void LoadData()
        {
            string json = PlayerPrefs.GetString(SAVE_KEY, "");
            if (!string.IsNullOrEmpty(json))
            {
                try
                {
                    Data = JsonUtility.FromJson<LevelMapData>(json);
                }
                catch (Exception e)
                {
                    Debug.LogError($"Failed to load level map data: {e.Message}");
                    Data = new LevelMapData();
                }
            }
        }

        public void SaveData()
        {
            try
            {
                string json = JsonUtility.ToJson(Data);
                PlayerPrefs.SetString(SAVE_KEY, json);
                PlayerPrefs.Save();
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to save level map data: {e.Message}");
            }
        }

        public void SetCurrentLevel(int levelId)
        {
            if (Data.currentLevel != levelId)
            {
                Data.currentLevel = levelId;
                OnCurrentLevelChanged?.Invoke(levelId);
                SaveData();
            }
        }

        public void UnlockLevel(int levelId)
        {
            var level = Data.GetLevel(levelId);
            if (level != null && !level.isUnlocked)
            {
                Data.UnlockLevel(levelId);
                OnLevelUnlocked?.Invoke(level);
                SaveData();
            }
        }
    }
}