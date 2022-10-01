using UnityEngine;

namespace ChoosingVacation.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Level", menuName = "LevelLogic/Level", order = 0)]
    public class LevelLogic : ScriptableObject
    {
        [Header("Level Settings")]
        [SerializeField] private string currentLevel;
        [SerializeField] private string nextLevel;
        [Header("Objects Found Settings")]
        [SerializeField] private int minObjectsFound;
        [SerializeField] private int maxObjectsFound;

        public string CurrentLevel => currentLevel;
        public string NextLevel => nextLevel;
        public int MinObjectsFound => minObjectsFound;
        public int MaxObjectsFound => maxObjectsFound;
    }
}