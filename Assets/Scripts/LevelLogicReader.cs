using System;
using ChoosingVacation.ScriptableObjects;
using UnityEngine;

namespace ChoosingVacation
{
    public class LevelLogicReader : MonoBehaviour
    {
        [SerializeField] private LevelLogicList levelLogicList;
        [SerializeField] private IntValue currentLevel;
        [SerializeField] private IntValue objectsFound;

        private void Awake()
        {
            foreach (LevelLogic _levelLogic in levelLogicList.ListLevelLogic)
            {
                var _currentLevel = ReadCurrentLevel(_levelLogic);
                var _nextLevel = ReadNextLevel(_levelLogic);
                var _objectsFoundRange = ReadObjectsFoundRange(_levelLogic);
                // Debug.Log($"Current Level: {_currentLevel}, Next Level: {_nextLevel}, Objects Found Range: {_objectsFoundRange[0]} - {_objectsFoundRange[1]}");

                if (_currentLevel == currentLevel.Value && (_objectsFoundRange[0] <= objectsFound.Value &&
                                                            objectsFound.Value <= _objectsFoundRange[1]))
                {
                    Debug.Log($"Current Level: {_currentLevel}, Next Level: {_nextLevel}, Objects Found Range: {_objectsFoundRange[0]} - {_objectsFoundRange[1]}");
                    return;
                }
            }
        }
        

        private int ReadCurrentLevel(LevelLogic levelLogic)
        {
            return levelLogic.CurrentLevel;
        }

        private int ReadNextLevel(LevelLogic levelLogic)
        {
            return levelLogic.NextLevel;
        }

        private int[] ReadObjectsFoundRange(LevelLogic levelLogic)
        {
            int[] objectsFoundRange = { levelLogic.MinObjectsFound, levelLogic.MaxObjectsFound };
            return objectsFoundRange;
        }
    }
}