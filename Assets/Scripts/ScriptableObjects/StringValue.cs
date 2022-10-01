using UnityEngine;

namespace ChoosingVacation.ScriptableObjects
{
    [CreateAssetMenu(fileName = "StringValue", menuName = "Value/String")]
    public class StringValue : ScriptableObject
    {
        [SerializeField] private string value;

        public string Value
        {
            get => value;
            set => this.value = value;
        }
    }
}