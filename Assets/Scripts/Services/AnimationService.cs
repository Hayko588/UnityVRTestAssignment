using UnityEngine;

namespace Services
{
    public class AnimationService : IAnimationService
    {
        private Animator _currentAnimator;

        public void SetAnimator(Animator animator)
        {
            _currentAnimator = animator;
        }

        public void PlayAnimation(string animationName)
        {
            _currentAnimator?.Play(animationName);
        }

        public void StopAnimation()
        {
            _currentAnimator?.SetTrigger("Stop");
        }
    }
}