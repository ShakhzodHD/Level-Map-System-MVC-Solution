using UnityEditor;
using UnityEngine;

namespace LevelMapModule
{
    public class ClearPlayerPrefsTool : EditorWindow
    {
        [MenuItem("LevelMap/Clear Player Prefs")]
        public static void ShowWindow()
        {
            GetWindow<ClearPlayerPrefsTool>("Clear Player Prefs");
        }

        private void OnGUI()
        {
            GUILayout.Label("Clear Player Prefs", EditorStyles.boldLabel);

            if (GUILayout.Button("Delete All Player Prefs"))
            {
                if (EditorUtility.DisplayDialog(
                    "Confirmation",
                    "Are you sure you want to delete all PlayerPrefs?",
                    "Yes", "No"))
                {
                    PlayerPrefs.DeleteAll();
                    PlayerPrefs.Save();
                    Debug.Log("All PlayerPrefs have been deleted.");
                }
            }
        }
    }
}