using UnityEngine;

namespace LevelMapModule
{
    public class LevelMapManualInstaller : MonoBehaviour, ILevelMapInstaller
    {
        [SerializeField] private LevelMapView levelMapView;
        [SerializeField] private int totalLevels = 50;

        private ILevelMapController controller;

        public ILevelMapController Install()
        {
            if (controller != null)
                return controller;

            var model = new LevelMapModel();
            InitializeModel(model);

            ILevelMapView view = levelMapView;
            if (view == null)
            {
                view = FindObjectOfType<LevelMapView>();
                if (view == null)
                {
                    Debug.LogError("LevelMapView not found! Please assign it in the inspector.");
                    return null;
                }
            }

            controller = new LevelMapController(model, view);
            controller.Initialize();

            return controller;
        }

        private void InitializeModel(LevelMapModel model)
        {
            model.LoadData();

            if (model.Data.levels.Count == 0)
            {
                for (int i = 1; i <= totalLevels; i++)
                {
                    model.Data.levels.Add(new LevelData(i));
                }
                model.SaveData();
            }
        }

        private void Start()
        {
            // Auto-install if needed
            Install();
        }
    }
}