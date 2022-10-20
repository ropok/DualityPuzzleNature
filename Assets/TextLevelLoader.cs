using ChoosingVacation.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace ChoosingVacation
{
    public class TextLevelLoader : MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] private StringValue text1;
        [SerializeField] private StringValue mainText;
        [SerializeField] private StringValue placeText;
        [SerializeField] private IntValue objectFound;

        private void Awake()
        {
            text.text = text1.Value;
        }

        private string UpdateTextTransition(StringValue _mainString, IntValue _intValue, StringValue _stringValue)
        {
            string _textLevelLoader = string.Format(_mainString.Value, _intValue.Value.ToString(), _stringValue.Value);
            return _textLevelLoader;
        }

        public void UpdateTextLevel()
        {
            text.text = UpdateTextTransition(mainText, objectFound, placeText);
        }
        public void UpdateText(StringValue _string)
        {
            text.text = _string.Value;
        }
    }
}
