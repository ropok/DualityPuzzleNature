using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    [SerializeField]
    private float timeLimit;
    //[SerializeField]
    //private List<HiddenObjectData> hiddenObjectList;
    public List<GameObject> levelList = new List<GameObject>();
    private GameObject level;

    //private List<HiddenObjectData> activeHiddenObjectList;
    private GameObject objectHolderPrefab;
    public GameObject greenMark;

    private int totalHiddenObjectsFound = 0;
    private float currentTime = 0;
    private GameStatus gameStatus = GameStatus.NEXT;
    private GameLevel gameLevel = GameLevel.LEVEL_A;

    public Animator transition;
    public float transitionTime = 3f;
    //private bool isCrossFade = true;
    public GameObject transitionPanel;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) Destroy(gameObject);
    }

    private void Start()
    {
        transitionPanel.SetActive(true);
        StartCoroutine(CrossFadeInitiation());
        Invoke("InitGameplay", transitionTime);
    }
    
    void InitGameplay()
    {
        UIManager.instance.TimerText.gameObject.SetActive(true);
        UIManager.instance.ObjectCount.gameObject.SetActive(true);
        LoadLevel();
        InitiateHiddenObjects();

    }

    void InitiateHiddenObjects()
    {
        currentTime = timeLimit;
        UIManager.instance.TimerText.text = "" + currentTime;
        totalHiddenObjectsFound = 0;
        UIManager.instance.ObjectCount.text = "" + totalHiddenObjectsFound;
        //activeHiddenObjectList.Clear();

        gameStatus = GameStatus.PLAYING;
    }

    void LoadLevel()
    {
        DestroyMark();
        level = Instantiate(levelList[(int)gameLevel], Vector3.zero, Quaternion.identity);
    }

    void DestroyMark()
    {
        GameObject[] marks = GameObject.FindGameObjectsWithTag("Mark");
        foreach (GameObject mark in marks)
            GameObject.Destroy(mark);

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
        if (totalHiddenObjectsFound < 3)
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
        else if (totalHiddenObjectsFound >= 3)
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
        StartCoroutine(CrossfadeInAnimation());
        StartCoroutine(CrossfadeOutAnimation());
        Invoke("InitiateHiddenObjects", transitionTime);
        Invoke("LoadLevel", transitionTime);


    }

    private void Update()
    {
        if (gameStatus == GameStatus.PLAYING)
        {

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 mark = new Vector3(pos[0], pos[1], 1);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.zero);

                if (hit && hit.collider != null)
                {
                    //Debug.Log("Object Name:" + hit.collider.gameObject.name);
                    hit.collider.enabled = false;
                    Instantiate(greenMark, mark, Quaternion.identity);


                    totalHiddenObjectsFound++;
                    UIManager.instance.ObjectCount.text = "" + totalHiddenObjectsFound;
                    //Debug.Log("Hidden Objects Found: " + totalHiddenObjectsFound);
                }

            }

            currentTime -= Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            UIManager.instance.TimerText.text = time.ToString("mm':'ss");

            if (currentTime <= 0)
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
            UIManager.instance.TimerText.gameObject.SetActive(false);
            UIManager.instance.ObjectCount.gameObject.SetActive(false);
            Debug.Log("Game Over!");
        }
    }



}

[System.Serializable]

public class HiddenObjectData
{
    public string name;
    public GameObject hiddenObject;
    //public bool makeHidden = false;
}

public enum GameStatus
{
    PLAYING,
    NEXT,
    END
}

public enum GameLevel
{
    LEVEL_A, // Level Home
    LEVEL_B, // Level Airport
    LEVEL_C, // Level Train Station
    LEVEL_D, // Level Beach
    LEVEL_E  // Level Camp
}