using ChoosingVacation.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace ChoosingVacation
{
    public class UIObjectCounting : MonoBehaviour
    {
        [SerializeField] private Text textObjectCount;
        [SerializeField] private IntValue count;

        private void Awake()
        {
            ApplyText(count.Value.ToString());
        }

        private void Update()
        {
            ApplyText(count.Value.ToString());
        }

        void ApplyText(string text)
        {
            textObjectCount.text = text;
        }
    }
}
