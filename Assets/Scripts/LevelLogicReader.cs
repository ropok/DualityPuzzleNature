using System;
using ChoosingVacation.ScriptableObjects;
using UnityEngine;

namespace ChoosingVacation
{
    public class LevelLogicReader : MonoBehaviour
    {
        private LevelLogicList levelLogicList;
        private IntValue currentLevel;
        private IntValue nextLevel;
        private IntValue objectsFound;

        private LevelDatabase levelDatabase;
        private void Awake()
        {
            levelDatabase = GetComponent<LevelDatabase>();
            levelLogicList = levelDatabase.levelLogicList;
            currentLevel = levelDatabase.currentLevel;
            nextLevel = levelDatabase.nextLevel;
            objectsFound = levelDatabase.objectsFound;
        }

        public void GenerateNextLevel()
        {
            foreach (var levelLogic in levelLogicList.ListLevelLogic)
            {
                var logicCurrentLevel = levelLogic.CurrentLevel;
                int[] objectsFoundRange = {levelLogic.MinObjectsFound, levelLogic.MaxObjectsFound};

                if (logicCurrentLevel != currentLevel.Value || (objectsFoundRange[0] > objectsFound.Value ||
                                                                objectsFound.Value > objectsFoundRange[1])) continue;
                nextLevel.Value = levelLogic.NextLevel;
                return;
            }

        }
        
    }
}