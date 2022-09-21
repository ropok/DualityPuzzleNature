using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        FindObjectOfType<AudioManager>().Play("Gameplay");
        transitionPanel.SetActive(true);
        UIManager.instance.LevelText.text = "" + textLevelList[(int)gameLevel];
        StartCoroutine(CrossFadeInitiation());
        Invoke("InitGameplay", transitionTime);
    }

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

    void DestroyGreenMark()
    {
        if (AllEnabledGreenMarks.AllGreenMarks.Count <= 0) return;

        foreach (var greenMark in AllEnabledGreenMarks.AllGreenMarks.ToList())
        {
            Destroy(greenMark.gameObject);
        }
    }

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

    /*
     * RULES HERE
     * if Objects Found equal to x, and times out.
     * Game ends at Level_D or Level_E
     */
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

        textLevelList[(int)gameLevel] = string.Format(textLevelList[(int)gameLevel], ObjectsFound.objectsFound.ToString());
        UIManager.instance.LevelText.text = "" + textLevelList[(int)gameLevel];
        Debug.Log(textLevelList[(int)gameLevel]);
        StartCoroutine(CrossfadeInAnimation());
        StartCoroutine(CrossfadeOutAnimation());
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
        if (gameStatus == GameStatus.PLAYING)
        {
            if (!timer.isTimeRunning)
            {
                level.SetActive(false);
                ObjectsFoundCheck();
            }

        }
        /*
         * Initiate new Level here
         * Load new Objects
         * Load new image
         */
        else if (gameStatus == GameStatus.NEXT)
        {
            Debug.Log("Load next level");
        }

        else if (gameStatus == GameStatus.END)
        {

            // Change music
        }
    }


    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}

[System.Serializable]

public class HiddenObjectData
{
    public string name;
    public GameObject hiddenObject;
    //public bool makeHidden = false;
}
