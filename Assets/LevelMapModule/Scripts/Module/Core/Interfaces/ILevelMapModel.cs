using System;

namespace LevelMapModule
{
    public interface ILevelMapModel
    {
        LevelMapData Data { get; }
        event Action<LevelData> OnLevelUnlocked;
        event Action<LevelData> OnLevelCompleted;
        event Action<int> OnCurrentLevelChanged;

        void LoadData();
        void SaveData();
        void UnlockLevel(int levelId);
        void CompleteLevel(int levelId, int stars = 0);
        void SetCurrentLevel(int levelId);
        LevelData GetLevel(int levelId);
    }
}