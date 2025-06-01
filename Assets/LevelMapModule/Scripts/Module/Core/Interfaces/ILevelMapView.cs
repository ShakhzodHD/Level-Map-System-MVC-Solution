using System;

namespace LevelMapModule
{
    public interface ILevelMapView
    {
        event Action<int> OnLevelButtonClicked;
        event Action OnBackButtonClicked;

        void Initialize(LevelMapData data);
        void UpdateLevel(LevelData levelData);
        void ShowLevelMap();
        void HideLevelMap();
        void SetInteractable(bool interactable);
    }
}