using UnityEngine;

namespace ChoosingVacation
{
    public class GreenMark : MonoBehaviour
    {

        private void OnEnable()
        {
            AllEnabledGreenMarks.AllGreenMarks.Add(this);
        }

        private void OnDisable()
        {
            AllEnabledGreenMarks.AllGreenMarks.Remove(this);
        }
    }
}
