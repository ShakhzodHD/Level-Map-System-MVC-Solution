using System.Collections.Generic;
using System;
using UnityEngine;

namespace LevelMapModule
{
    public class LevelMapView : MonoBehaviour, ILevelMapView
    {
        [SerializeField] private LevelMapViewSettings settings;

        private readonly Dictionary<int, LevelButton> levelButtons = new();

        public event Action<int> OnLevelButtonClicked;
        public event Action OnBackButtonClicked;

        private void Awake()
        {
            if (settings.backButton != null)
            {
                settings.backButton.onClick.AddListener(() => OnBackButtonClicked?.Invoke());
            }
        }

        public void Initialize(LevelMapData data)
        {
            ClearButtons();
            CreateLevelButtons(data);
        }

        private void ClearButtons()
        {
            foreach (var button in levelButtons.Values)
            {
                if (button != null && button.gameObject != null)
                {
                    DestroyImmediate(button.gameObject);
                }
            }
            levelButtons.Clear();
        }

        private void CreateLevelButtons(LevelMapData data)
        {
            for (int i = 0; i < data.levels.Count; i++)
            {
                var levelData = data.levels[i];
                CreateLevelButton(levelData, i);
            }
        }

        private void CreateLevelButton(LevelData levelData, int index)
        {
            if (settings.levelButtonPrefab == null || settings.levelButtonsContainer == null)
                return;

            var buttonObj = Instantiate(settings.levelButtonPrefab, settings.levelButtonsContainer);
            
            if (!buttonObj.TryGetComponent<LevelButton>(out var levelButton))
            {
                levelButton = buttonObj.AddComponent<LevelButton>();
            }

            int row = index / settings.buttonsPerRow;
            int col = index % settings.buttonsPerRow;

            var rectTransform = buttonObj.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(
                col * settings.buttonSpacing,
                -row * settings.buttonSpacing
            );

            levelButton.Initialize(levelData);
            levelButton.OnClicked += (id) => OnLevelButtonClicked?.Invoke(id);

            levelButtons[levelData.levelId] = levelButton;
        }

        public void SetInteractable(bool interactable)
        {
            foreach (var button in levelButtons.Values)
            {
                button.SetInteractable(interactable);
            }

            if (settings.backButton != null)
            {
                settings.backButton.interactable = interactable;
            }
        }

        public void ShowLevelMap()
        {
            if (settings.mapCanvas != null)
            {
                settings.mapCanvas.gameObject.SetActive(true);
            }
        }

        public void HideLevelMap()
        {
            if (settings.mapCanvas != null)
            {
                settings.mapCanvas.gameObject.SetActive(false);
            }
        }

        public void UpdateLevel(LevelData levelData)
        {
            if (levelButtons.TryGetValue(levelData.levelId, out var button))
            {
                button.UpdateData(levelData);
            }
        }
    }
}