using UnityEngine;

namespace GAD210.P2.Iteration1.Player
{
    /// <summary>
    /// This class handles opening and closing the exit window for the player during the game
    /// </summary>
    public class ExitWindow : MonoBehaviour
    {
        #region Variables

        [Header("Game Objects")]

        [Tooltip("The prompt of the Exit Window. The element informng the player about their descision to close the game")]
        [SerializeField] private GameObject exitPrompt;

        #endregion

        #region Methods

        public void ToggleExitPrompt(bool valueToSetTo)
        {
            exitPrompt.SetActive(valueToSetTo);
        }

        public void ExitGame()
        {
            Application.Quit();
            Debug.Log("Exited game!");
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            ToggleExitPrompt(false);
        }

        #endregion
    }
}