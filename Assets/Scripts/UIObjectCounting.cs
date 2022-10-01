using UnityEngine;
using UnityEngine.UI;

namespace ChoosingVacation
{
    public class UIObjectCounting : MonoBehaviour
    {
        [SerializeField] private Text textObjectCount;

        private void Awake()
        {
            ApplyText(ObjectsFound.objectsFound.ToString());
        }

        private void Update()
        {
            ApplyText(ObjectsFound.objectsFound.ToString());
        }

        void ApplyText(string text)
        {
            textObjectCount.text = text;
        }
    }
}
