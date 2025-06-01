namespace LevelMapModule
{
    public interface ILevelMapController
    {
        void Initialize();
        void ShowLevelMap();
        void HideLevelMap();
        void CompleteLevel(int levelId, int stars = 0);
        void UnlockLevel(int levelId);
        LevelData GetLevel(int levelId);
    }
}