using System;
using UnityEngine;
using UnityEngine.UI;

namespace LevelMapModule
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Text levelText;
        [SerializeField] private Image levelIcon;
        [SerializeField] private GameObject[] stars;
        [SerializeField] private GameObject lockIcon;
        [SerializeField] private GameObject completedIcon;

        private LevelData levelData;

        public event Action<int> OnClicked;

        private void Awake()
        {
            if (button == null) button = GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(HandleClick);
            }
        }

        public void Initialize(LevelData data)
        {
            levelData = data;
            UpdateData(data);
        }
        public void UpdateData(LevelData data)
        {
            levelData = data;

            if (levelText != null)
            {
                levelText.text = data.levelId.ToString();
            }

            if (levelIcon != null && data.levelIcon != null)
            {
                levelIcon.sprite = data.levelIcon;
            }

            if (stars != null)
            {
                for (int i = 0; i < stars.Length; i++)
                {
                    if (stars[i] != null)
                    {
                        stars[i].SetActive(i < data.stars);
                    }
                }
            }

            if (lockIcon != null)
            {
                lockIcon.SetActive(!data.isUnlocked);
            }

            if (completedIcon != null)
            {
                completedIcon.SetActive(data.isCompleted);
            }

            if (button != null)
            {
                button.interactable = data.isUnlocked;
            }
        }

        public void SetInteractable(bool interactable)
        {
            if (button != null)
            {
                button.interactable = interactable && levelData.isUnlocked;
            }
        }

        private void HandleClick()
        {
            if (levelData != null && levelData.isUnlocked)
            {
                OnClicked?.Invoke(levelData.levelId);
            }
        }
    }
}