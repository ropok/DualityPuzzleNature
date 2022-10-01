using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ChoosingVacation
{
    public class LevelManagerIntro : MonoBehaviour
    {
        public static LevelManagerIntro instance;
        public List<GameObject> IntroGameplay = new List<GameObject>();
        private GameObject introGameplay;
        private StatusScene statusScene;
        private int introScene;

        public Animator transition;
        public float transitionFadeOutTime = 1f;
        private float transitionFadeInTime = 1f;
        public GameObject transitionPanel;

    
        private void Awake()
        {
            if (instance == null) instance = this;
            else if (instance != null) Destroy(gameObject);
        }

        /*
     * Initiate Scene
     * * Fade out to show the first scene
     * * Load first intro scene
     *
     */
        private void Start()
        {
            transitionPanel.SetActive(true);
            introScene = 0;
            statusScene = StatusScene.PLAYING;
            LoadScene();
        }

        void LoadScene()
        {
            statusScene = StatusScene.PLAYING;

            if (introGameplay != null) introGameplay.SetActive(false);
            introGameplay = Instantiate(IntroGameplay[introScene], Vector3.zero, Quaternion.identity);

            StartCoroutine(CrossFadeOutAnimation());
            statusScene = StatusScene.END;
        }

        void LoadGameplay()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        IEnumerator CrossFadeOutAnimation()
        {
            transition.SetTrigger("FadeOut");
            yield return new WaitForSeconds(transitionFadeOutTime);
        }

        IEnumerator CrossFadeInAnimation()
        {
            transition.SetTrigger("FadeIn");
            yield return new WaitForSeconds(transitionFadeInTime);
        }

        private void Update()
        {
            if (statusScene == StatusScene.END)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (introScene < IntroGameplay.Count - 1)
                    {
                        // next scene
                        introScene++;
                        StartCoroutine(CrossFadeInAnimation());
                        Invoke(nameof(LoadScene), transitionFadeInTime);
                    } else
                    {
                        StartCoroutine(CrossFadeInAnimation());
                        Invoke(nameof(LoadGameplay), transitionFadeInTime);
                    }
                }

            }
        }

    }

    public enum StatusScene
    {
        PLAYING,
        END
    }
}