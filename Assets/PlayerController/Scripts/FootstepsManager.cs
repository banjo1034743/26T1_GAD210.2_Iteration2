using UnityEngine;

namespace GAD210.P2.Iteration1.Player
{
    /// <summary>
    /// This class handles the enabling and disabling of the player's footstep sound effects
    /// </summary>
    [RequireComponent(typeof(InputManager))]
    public class FootstepsManager : MonoBehaviour
    {
        #region Variables

        [Header("Game Objects")]

        [Tooltip("The game object we use for playing our footstep sound effects. It is enabled or disabled depending on if we're walking or not.")]
        [SerializeField] private GameObject footsteps;

        [Header("Scripts")]

        [Tooltip("Our reference to the InputManager. We need this for getting references to methods returning current input values to know when to activate footsteps.")]
        [SerializeField] private InputManager inputManager;

        #endregion

        #region Methods

        private void ToggleFootsteps()
        {
            if (inputManager.GetDirectionValue() == Vector2.zero)
            {
                footsteps.SetActive(false);
            }
            else
            {
                footsteps.SetActive(true);
            }
        }

        #endregion

        #region Unity Methods

        private void Update()
        {
            ToggleFootsteps();
        }

        #endregion
    }
}