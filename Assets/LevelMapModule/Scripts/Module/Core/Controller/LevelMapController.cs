using System;
using UnityEngine;

namespace LevelMapModule
{
    public class LevelMapController : ILevelMapController
    {
        private readonly ILevelMapModel model;
        private readonly ILevelMapView view;

        public event Action<int> OnLevelSelected;
        public event Action OnBackPressed;

        public LevelMapController(ILevelMapModel model, ILevelMapView view)
        {
            this.model = model;
            this.view = view;

            SubscribeToEvents();
        }
        private void SubscribeToEvents()
        {
            model.OnLevelUnlocked += HandleLevelUnlocked;
            model.OnLevelCompleted += HandleLevelCompleted;
            model.OnCurrentLevelChanged += HandleCurrentLevelChanged;

            view.OnLevelButtonClicked += HandleLevelButtonClicked;
            view.OnBackButtonClicked += HandleBackButtonClicked;
        }
        public void Initialize()
        {
            model.LoadData();
            view.Initialize(model.Data);
        }

        public void ShowLevelMap()
        {
            view.ShowLevelMap();
        }

        public void HideLevelMap()
        {
            view.HideLevelMap();
        }

        public void CompleteLevel(int levelId, int stars = 0)
        {
            model.CompleteLevel(levelId, stars);
        }

        public void UnlockLevel(int levelId)
        {
            model.UnlockLevel(levelId);
        }
        public LevelData GetLevel(int levelId)
        {
            return model.GetLevel(levelId);
        }
        private void HandleLevelUnlocked(LevelData levelData)
        {
            view.UpdateLevel(levelData);
        }

        private void HandleLevelCompleted(LevelData levelData)
        {
            view.UpdateLevel(levelData);
        }

        private void HandleCurrentLevelChanged(int levelId)
        {
            // Update UI to show current level selection
        }
        private void HandleLevelButtonClicked(int levelId)
        {
            model.SetCurrentLevel(levelId);
            OnLevelSelected?.Invoke(levelId);
        }
        private void HandleBackButtonClicked()
        {
            OnBackPressed?.Invoke();
        }
        public void Dispose()
        {
            if (model != null)
            {
                model.OnLevelUnlocked -= HandleLevelUnlocked;
                model.OnLevelCompleted -= HandleLevelCompleted;
                model.OnCurrentLevelChanged -= HandleCurrentLevelChanged;
            }

            if (view != null)
            {
                view.OnLevelButtonClicked -= HandleLevelButtonClicked;
                view.OnBackButtonClicked -= HandleBackButtonClicked;
            }
        }
    }
}