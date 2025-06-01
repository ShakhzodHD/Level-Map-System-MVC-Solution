using UnityEngine;
using UnityEngine.UI;

namespace LevelMapModule
{
    public class GameplayManager : MonoBehaviour
    {
        [SerializeField] private Button completeButton;

        private void Start()
        {
            if (completeButton != null)
                completeButton.onClick.AddListener(CompleteLevel);
        }
        private void CompleteLevel()
        {
            LevelMapManager.Instance.CompleteLevel(3); // Example: Completing level 3 with 3 stars
            LevelMapManager.Instance.ReturnToMap();
        }
    }
}