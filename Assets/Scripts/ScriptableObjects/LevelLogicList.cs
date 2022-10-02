using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChoosingVacation.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Level", menuName = "LevelLogic/ListLevel", order = 0)]
    public class LevelLogicList : ScriptableObject, IEnumerable
    {
        [SerializeField] private List<LevelLogic> listLevelLogic;


        public List<LevelLogic> ListLevelLogic => listLevelLogic;
        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}