using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{

    public static TransitionManager instance;

    public Animator transition;
    private float transitionFadeOutTime = 1f;
    public GameObject transitionPanel;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) Destroy(gameObject);
    }

    private void Start()
    {
        transitionPanel.SetActive(true);
        StartCoroutine(CrossFadeOutAnimation());
        
    }

    IEnumerator CrossFadeOutAnimation()
    {
        transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(transitionFadeOutTime);
    }

}
