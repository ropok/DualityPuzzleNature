using UnityEngine;

namespace ChoosingVacation.ScriptableObjects
{
    [CreateAssetMenu(fileName = "FloatValue", menuName = "Value/Float")]
    public class FloatValue : ScriptableObject
    {
        [SerializeField] private float value;

        public float Value
        {
            get => value;
            set => this.value = value;
        }

        public void SetValue(float _value)
        {
            this.value = _value;
        }

        public void SetValue(FloatValue _value)
        {
            this.value = _value.value;
        }

    }
}
