using UnityEngine;

namespace ChoosingVacation.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Level", menuName = "LevelLogic/Level", order = 0)]
    public class LevelLogic : ScriptableObject
    {
        [Header("Level Settings")]
        [SerializeField] private int currentLevel;
        [SerializeField] private int nextLevel;
        [Header("Objects Found Settings")]
        [SerializeField] private int minObjectsFound;
        [SerializeField] private int maxObjectsFound;

        public int CurrentLevel => currentLevel;
        public int NextLevel => nextLevel;
        public int MinObjectsFound => minObjectsFound;
        public int MaxObjectsFound => maxObjectsFound;
    }
}