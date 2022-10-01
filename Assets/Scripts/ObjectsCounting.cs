using UnityEngine;
using UnityEngine.UI;

namespace ChoosingVacation
{
    public class ObjectsCounting : MonoBehaviour
    {
        private Text text;

        private void Awake()
        {
            text = GetComponent<Text>();
            ObjectsFound.objectsFound = 0;
        }

        private void Update()
        {
            text.text = ObjectsFound.objectsFound.ToString();
        }
    }
}
