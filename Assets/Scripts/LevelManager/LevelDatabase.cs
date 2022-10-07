using System.Collections.Generic;
using ChoosingVacation.ScriptableObjects;
using UnityEngine;

namespace ChoosingVacation.LevelManager
{
    public class LevelDatabase : MonoBehaviour 
    {
        public List<GameObject> levelList;
        public LevelLogicList levelLogicList;
        public IntValue currentLevel;
        public IntValue nextLevel;
        public IntValue objectsFound;
        public GameObject LevelLoaded { get; set; }
    }

}