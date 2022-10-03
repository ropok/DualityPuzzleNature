using System;
using System.Collections.Generic;
using UnityEngine;

namespace ChoosingVacation
{
    public class LevelLoader : MonoBehaviour
    {


        private LevelDatabase levelDatabase;
        private List<GameObject> levelList;

        private void Awake()
        {
            levelDatabase = GetComponent<LevelDatabase>();
            levelList = levelDatabase.levelList;
        }
    }
}
