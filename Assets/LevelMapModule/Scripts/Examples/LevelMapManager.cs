using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelMapModule
{
    public class LevelMapManager : MonoBehaviour
    {
        [Header("Scene Management")]
        [SerializeField] private string gameplayScenePrefix = "Level_";
        [SerializeField] private string levelMapScene = "DemoLevelMap";

        [SerializeField] private LevelMapManualInstaller installer;
        private ILevelMapController controller;

        public static LevelMapManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            controller = installer.Install();

            if (controller != null)
            {
                SetupController();
            }
        }

        private void SetupController()
        {
            var levelController = controller as LevelMapController;
            levelController.OnLevelSelected += LoadLevel;
            levelController.OnBackPressed += ShowMainMenu;

            controller.ShowLevelMap();
        }

        private void LoadLevel(int levelId)
        {
            PlayerPrefs.SetInt("CurrentLevel", levelId);
            PlayerPrefs.Save();

            string sceneName = gameplayScenePrefix + levelId;
            SceneManager.LoadScene(sceneName);

            gameObject.SetActive(false);
        }

        public void CompleteLevel(int stars)
        {
            int currentLevel = PlayerPrefs.GetInt("CurrentLevel");

            controller.CompleteLevel(currentLevel, stars);
        }

        public void ReturnToMap()
        {
            SceneManager.LoadScene(levelMapScene);

            gameObject.SetActive(true);
        }

        private void ShowMainMenu()
        {
            controller.HideLevelMap();
            Debug.Log("Back to main menu");
        }
    }
}