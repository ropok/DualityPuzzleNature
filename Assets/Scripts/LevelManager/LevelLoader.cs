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
            levelDatabase.LevelLoaded = Instantiate(levelList[nextLevel], Vector3.zero, Quaternion.identity);
        }

        public void UnloadLevel()
        {
            Destroy(levelDatabase.LevelLoaded);
        }

    }
}
