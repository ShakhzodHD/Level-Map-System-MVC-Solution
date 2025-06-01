using System;
using UnityEngine;

namespace LevelMapModule
{
    [Serializable]
    public class LevelData
    {
        public int levelId;
        public bool isUnlocked;
        public bool isCompleted;
        public int stars;
        public Vector2 mapPosition;
        public string levelName;
        public Sprite levelIcon;

        public LevelData(int id)
        {
            levelId = id;
            isUnlocked = id == 1;
            isCompleted = false;
            stars = 0;
            levelName = $"Level {id}";
        }
    }
}