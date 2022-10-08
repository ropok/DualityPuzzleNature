using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ChoosingVacation
{
    public class GameManager : MonoBehaviour
    {
        public List<GameObject> levelList = new List<GameObject>();
        private GameObject level;

        public List<String> textLevelList = new List<String>();

        private GameStatus gameStatus = GameStatus.NEXT;
        private GameLevel gameLevel = GameLevel.LEVEL_A;

        public Animator transition;
        public float transitionTime = 3f;
        public GameObject transitionPanel;

        private Timer timer;

        private int _objectsFound;

        private void Awake()
        {
            timer = GetComponent<Timer>();
            //_objectsFound = ObjectsFound.objectsFound;
        }

        private void Start()
        {
            // #Audio
            FindObjectOfType<AudioManager>().Play("Gameplay");
            // #Transition
            transitionPanel.SetActive(true);
            // #Load Level - UI text
            UIManager.instance.LevelText.text = "" + textLevelList[(int)gameLevel];
            // #Transition
            StartCoroutine(CrossFadeInitiation());
            // #Load Level - Initiation
            Invoke("InitGameplay", transitionTime);
        }

        // #Load Level - Initiation
        void InitGameplay()
        {
            UIManager.instance.ButtonExit.gameObject.SetActive(false);
            UIManager.instance.ObjectCount.gameObject.SetActive(true);
            LoadLevel();
            InitiateHiddenObjects();
        }

        void InitiateHiddenObjects()
        {
            timer.StartTimer();
            gameStatus = GameStatus.PLAYING;
        }

        void LoadLevel()
        {
            DestroyGreenMark();
            ObjectsFound.objectsFound = 0;
            level = Instantiate(levelList[(int)gameLevel], Vector3.zero, Quaternion.identity);
        }

        // #Destroy Objects
        void DestroyGreenMark()
        {
            if (AllEnabledGreenMarks.AllGreenMarks.Count <= 0) return;

            foreach (var greenMark in AllEnabledGreenMarks.AllGreenMarks.ToList())
            {
                Destroy(greenMark.gameObject);
            }
        }

        // #Transition
        IEnumerator CrossFadeInitiation()
        {
            yield return new WaitForSeconds(transitionTime);
            transition.SetTrigger("FadeOut");
        }

        IEnumerator CrossfadeOutAnimation()
        {
            yield return new WaitForSeconds(transitionTime);
            transition.SetTrigger("FadeOut");
        }
        IEnumerator CrossfadeInAnimation()
        {
            transition.SetTrigger("FadeIn");
            yield return new WaitForSeconds(1);

        }

        // #Level Logic
        /*
     * RULES HERE
     * if Objects Found equal to x, and times out.
     * Game ends at Level_D or Level_E
     */
        // Rules of the game
        void ObjectsFoundCheck()
        {
            // if total Objects Found < 3
            if (ObjectsFound.objectsFound < 3)
            {
                if (gameLevel == GameLevel.LEVEL_A)
                {
                    Debug.Log("Jump to level B");
                    gameLevel = GameLevel.LEVEL_B;
                    gameStatus = GameStatus.NEXT;
                }

                else if (gameLevel == GameLevel.LEVEL_B)
                {
                    Debug.Log("Jump to level E");
                    gameLevel = GameLevel.LEVEL_E;
                    gameStatus = GameStatus.END;
                }

                else if (gameLevel == GameLevel.LEVEL_C)
                {
                    Debug.Log("Jump to level D");
                    gameLevel = GameLevel.LEVEL_D;
                    gameStatus = GameStatus.END;
                }
            }

            // if total Objects Found >= 3
            else if (ObjectsFound.objectsFound >= 3)
            {
                if (gameLevel == GameLevel.LEVEL_A)
                {
                    Debug.Log("Jump to level C");
                    gameLevel = GameLevel.LEVEL_C;
                    gameStatus = GameStatus.NEXT;
                }

                else if (gameLevel == GameLevel.LEVEL_B)
                {
                    Debug.Log("Jump to level D");
                    gameLevel = GameLevel.LEVEL_D;
                    gameStatus = GameStatus.END;
                }

                else if (gameLevel == GameLevel.LEVEL_C)
                {
                    Debug.Log("Jump to level E");
                    gameLevel = GameLevel.LEVEL_E;
                    gameStatus = GameStatus.END;
                }
            }

            // #Load Level - UI
            // Load Next Level Variables
            textLevelList[(int)gameLevel] = string.Format(textLevelList[(int)gameLevel], ObjectsFound.objectsFound.ToString());
            UIManager.instance.LevelText.text = "" + textLevelList[(int)gameLevel];
            Debug.Log(textLevelList[(int)gameLevel]);
            // #Transition
            StartCoroutine(CrossfadeInAnimation());
            StartCoroutine(CrossfadeOutAnimation());
            // #Load level - END
            if (gameStatus != GameStatus.END)
            {
                Invoke("InitiateHiddenObjects", transitionTime);
            }
            else
            {
                UIManager.instance.ButtonExit.gameObject.SetActive(true);
                UIManager.instance.ObjectCount.gameObject.SetActive(false);
                FindObjectOfType<AudioManager>().Stop("Gameplay");
                FindObjectOfType<AudioManager>().Play("Ending");
            }
            Invoke("LoadLevel", transitionTime);


        }


        private void Update()
        {
            // Running the game
            if (gameStatus == GameStatus.PLAYING)
            {
                // #Event - times up
                if (!timer.isTimeRunning)
                {
                    level.SetActive(false);
                    ObjectsFoundCheck();
                }

            }
            
            // Loading Next Level
            else if (gameStatus == GameStatus.NEXT)
            {
                Debug.Log("Load next level");
            }

            // Condition where game is ended
            else if (gameStatus == GameStatus.END)
            {

                // Change music
            }
        }


        // #SceneManager
        public void ExitToMainMenu()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
    }
}