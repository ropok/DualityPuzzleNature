using ChoosingVacation.Events;
using ChoosingVacation.ScriptableObjects;
using UnityEngine;

namespace ChoosingVacation
{
    public class GameManagerNew : MonoBehaviour
    {
        [SerializeField] private GameEvent initLevel;
        [SerializeField] private GameEvent startLevel;
        [SerializeField] private GameEvent endLevel;
        [SerializeField] private GameEvent ending;
        [SerializeField] private GameEvent resetLevelData;
        [SerializeField] private FloatValue waitDuration;
        [SerializeField] private BoolValue isLevelEnding;
        [SerializeField] private BoolValue isLevelStarting;
        [SerializeField] private EnumValue gameStatus;

        private void Awake()
        {
            isLevelStarting.SetValue(false);
        }

        private void Update()
        {
            if (isLevelStarting.Value)
            {
                if (gameStatus.Value == GameStatus.InitLevel) InitLevel();
                if (gameStatus.Value == GameStatus.StartLevel) StartLevel();
                if (gameStatus.Value == GameStatus.End) Ending();
            }
            if (!isLevelStarting.Value) resetLevelData.Raise();
        }


        private void InitLevel()
        {
            initLevel.Raise();
            gameStatus.Value = !isLevelEnding.Value ? GameStatus.StartLevel : GameStatus.End;
        }

        private void StartLevel()
        {
            startLevel.Raise();
        }

        private void Ending()
        {
            ending.Raise();
            gameStatus.Value = GameStatus.Idle;
        }

        public void GameStatusEndLevel(EnumValue _gameStatus)
        {
            _gameStatus.Value = GameStatus.EndLevel;
        }
    }
}