using UnityEngine;

namespace ChoosingVacation.ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnumValue", menuName = "Value/Enum")]
    public class EnumValue : ScriptableObject
    {

        [SerializeField] private GameStatus value;
        
        public GameStatus Value
        {
            get => value;
            set => this.value = value;
        }
    }
}