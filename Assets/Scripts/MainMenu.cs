using UnityEngine;
using UnityEngine.SceneManagement;

namespace ChoosingVacation
{
    public class MainMenu : MonoBehaviour
    {

        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void QuitGame()
        {
            Debug.Log("QUIT!");
            Application.Quit();
        }
    }
}
