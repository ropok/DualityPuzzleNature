using UnityEngine;

namespace ChoosingVacation.ScriptableObjects
{
    [CreateAssetMenu(fileName = "IntValue", menuName = "Value/Int")]
    public class IntValue : ScriptableObject
    {
        [SerializeField] private int value;

        public int Value
        {
            get => value;
            set => this.value = value;
        }
    }
}