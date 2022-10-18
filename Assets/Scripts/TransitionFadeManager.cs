using ChoosingVacation.ScriptableObjects;
using System.Collections;
using UnityEngine;

namespace ChoosingVacation
{
    public class TransitionFadeManager : MonoBehaviour
    {
        [SerializeField] private Animator transition;
        [SerializeField] private FloatValue transitionTime;
        [SerializeField] private EnumValue gameStatus;
        private static readonly int FadeOut = Animator.StringToHash("FadeOut");
        private static readonly int FadeIn = Animator.StringToHash("FadeIn");

        public void CrossfadeOutAnimation()
        {
            transition.SetTrigger(FadeOut);
        }

        public void CrossfadeInAnimation()
        {
            transition.SetTrigger(FadeIn);
            StartCoroutine(WaitAnimationFadeIn());
        }

        private IEnumerator WaitAnimationFadeIn()
        {
            float animationLength = transition.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(animationLength);
            gameStatus.Value = GameStatus.InitLevel;
        }
    }
}