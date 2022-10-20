using ChoosingVacation.ScriptableObjects;
using System.Collections.Generic;
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
        public BoolValue isLevelEnding;
        public GameObject LevelLoaded { get; set; }
        public StringValue levelName;
    }

}