using UnityEngine;

namespace GAD210.P2.Iteration1.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimationManager : MonoBehaviour
    {
        #region Variables

        [Header("Components")]

        [Tooltip("This is the animator the PlayerController uses for changing sprites. A new movement will call an animation trigger here, which the animator uses to know which sprite to change to.")]
        [SerializeField] protected Animator playerAnimator;

        [Header("Scripts")]

        [Tooltip("Our reference to the InputManager, which we use for accessing input values for knowing which animation to play.")]
        [SerializeField] private InputManager inputManager;

        #endregion

        #region Methods

        public virtual void SetAnimationTriggerWalkingHorizontal()
        {
            switch (inputManager.GetDirectionValue().x)
            {
                case -1f:
                    ResetTriggers();
                    playerAnimator.SetTrigger("WalkingLeft");
                    break;
                case 1f:
                    ResetTriggers();
                    playerAnimator.SetTrigger("WalkingRight");
                    break;
            }
        }

        public virtual void SetAnimationTriggerWalkingVertical()
        {
            switch (inputManager.GetDirectionValue().y)
            {
                case -1f:
                    ResetTriggers();
                    playerAnimator.SetTrigger("WalkingDown");
                    break;
                case 1f:
                    ResetTriggers();
                    playerAnimator.SetTrigger("WalkingUp");
                    break;
            }
        }

        protected virtual void ResetTriggers()
        {
            playerAnimator.ResetTrigger("WalkingLeft");
            playerAnimator.ResetTrigger("WalkingRight");
            playerAnimator.ResetTrigger("WalkingDown");
            playerAnimator.ResetTrigger("WalkingUp");
        }

        #endregion
    }
}