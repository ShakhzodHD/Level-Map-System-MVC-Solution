using System;
using UnityEngine;
using UnityEngine.UI;

namespace LevelMapModule
{
    [Serializable]
    public class LevelMapViewSettings
    {
        public GameObject levelButtonPrefab;
        public Transform levelButtonsContainer;
        public Button backButton;
        public Canvas mapCanvas;
        public float buttonSpacing = 100f;
        public int buttonsPerRow = 5;
    }
}