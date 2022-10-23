using UnityEngine;
using UnityEngine.SceneManagement;

namespace ChoosingVacation
{
    public class ExitToMainMenu : MonoBehaviour
    {
        public void ToMainMenu()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
    }
}
