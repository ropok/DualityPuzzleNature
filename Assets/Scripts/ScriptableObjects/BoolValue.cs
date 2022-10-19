using UnityEngine;

namespace ChoosingVacation.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BoolValue", menuName = "Value/Bool")]
    public class BoolValue : ScriptableObject
    {
        [SerializeField] private bool value;

        public bool Value
        {
            get => value;
            set => this.value = value;
        }

        public void SetValue(bool _value)
        {
            this.value = _value;
        }

        public void SetValue(BoolValue _value)
        {
            this.value = _value.value;
        }
    }
}