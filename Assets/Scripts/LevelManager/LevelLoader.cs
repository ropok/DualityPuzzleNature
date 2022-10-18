using System.Collections.Generic;
using UnityEngine;

namespace ChoosingVacation.LevelManager
{
    public class LevelLoader : MonoBehaviour
    {
        private LevelDatabase levelDatabase;
        private List<GameObject> levelList;
        private int nextLevel;

        private void Awake()
        {
            levelDatabase = GetComponent<LevelDatabase>();
            levelList = levelDatabase.levelList;
            nextLevel = levelDatabase.nextLevel.Value;
        }

        public void LoadLevel()
        {
            nextLevel = levelDatabase.nextLevel.Value;
            levelDatabase.LevelLoaded = Instantiate(levelList[nextLevel], Vector3.zero, Quaternion.identity);
            levelDatabase.currentLevel.Value = nextLevel;
        }

        public void UnloadLevel()
        {
            Destroy(levelDatabase.LevelLoaded);
        }

    }
}
