using UnityEngine;

namespace ChoosingVacation
{
    public class TransitionFadeManager : MonoBehaviour
    {
        [SerializeField] private Animator transition;
        [SerializeField] private float transitionTime = 3f;
        private static readonly int FadeOut = Animator.StringToHash("FadeOut");
        private static readonly int FadeIn = Animator.StringToHash("FadeIn");

        public void CrossfadeOutAnimation()
        {
            transition.SetTrigger(FadeOut);
        }

        public void CrossfadeInAnimation()
        {
            transition.SetTrigger(FadeIn);

        }
    }
}