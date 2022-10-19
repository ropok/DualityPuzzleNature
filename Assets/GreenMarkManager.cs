using System.Linq;
using UnityEngine;

namespace ChoosingVacation
{
    public class GreenMarkManager : MonoBehaviour
    {

        public void DestroyGreenMark()
        {
            if (AllEnabledGreenMarks.AllGreenMarks.Count <= 0) return;

            foreach (var greenMark in AllEnabledGreenMarks.AllGreenMarks.ToList())
            {
                Destroy(greenMark.gameObject);
            }
        }
    }
}
