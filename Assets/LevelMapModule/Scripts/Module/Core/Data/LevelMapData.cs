using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelMapModule
{
    [Serializable]
    public class LevelMapData
    {
        public List<LevelData> levels = new();
        public int currentLevel = 1;
        public int maxUnlockedLevel = 1;

        public void UnlockLevel(int levelId)
        {
            var level = GetLevel(levelId);
            if (level != null)
            {
                level.isUnlocked = true;
                maxUnlockedLevel = Mathf.Max(maxUnlockedLevel, levelId);
            }
        }
        public void CompleteLevel(int levelId, int stars = 0)
        {
            var level = GetLevel(levelId);
            if (level != null)
            {
                level.isCompleted = true;
                level.stars = Mathf.Max(level.stars, stars);
            }
        }

        public LevelData GetLevel(int levelId)
        {
            return levels.Find(l => l.levelId == levelId);
        }
    }
}