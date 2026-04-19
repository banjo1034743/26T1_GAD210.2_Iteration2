using UnityEngine;
using GAD210.P2.Iteration1.SceneLoaderNamespace;

namespace GAD210.P2.Iteration1.DialogueSystem
{
    public class IntroCutsceneManager : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TextParser _textParser;

        [SerializeField] private SceneLoader _sceneLoader;

        #endregion

        #region Methods

        private void CheckForEndOfDialogue()
        {
            if (_textParser.CurrentDialogueLine >= _textParser.AmountOfDialogueLines)
            {
                _sceneLoader.LoadScene(2);
            }
        }

        #endregion

        #region Unity Methods

        private void Update()
        {
            CheckForEndOfDialogue();
        }

        #endregion
    }
}