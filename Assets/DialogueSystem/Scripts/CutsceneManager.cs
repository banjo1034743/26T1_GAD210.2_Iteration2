using UnityEngine;
using GAD210.P2.Iteration1.Player;
using UnityEngine.UI;

namespace GAD210.P2.Iteration1.DialogueSystem
{
    public class CutsceneManager : MonoBehaviour
    {
        #region Variables

        [Header("Game Objects")]

        [Space(5)]

        [SerializeField] private GameObject _arnoldCutscene;

        [SerializeField] private GameObject _winScreen;

        [SerializeField] private Button _exitGameButton;

        [Header("Scripts")]

        [Space(5)]

        [SerializeField] private TextParser _textParser;

        #endregion

        #region Methods

        public void EnableCutscene()
        {
            PlayerFreezer.instance.CantMove = true;

            PlayerFreezer.instance.CantInteract = true;

            _textParser.SetIsActiveValue(true);

            _arnoldCutscene.SetActive(true);
        }

        private void CheckForEndScreen()
        {
            if (_textParser.CurrentDialogueLine >= _textParser.AmountOfDialogueLines && _textParser.AmountOfDialogueLines != 0) // Hack but whatever
            {
                if (_winScreen.activeSelf == false)
                {
                    _winScreen.SetActive(true);
                    _exitGameButton.Select();

                    EnvironmentSoundPlayer.instance.PlaySFXClipAt("Victory Horn", _winScreen.transform.position, 1, false);
                    EnvironmentSoundPlayer.instance.PlaySFXClipAt("Party Horn", _winScreen.transform.position, 1, false);
                    EnvironmentSoundPlayer.instance.PlaySFXClipAt("Child Cheer", _winScreen.transform.position, 1, false);
                }
            }
        }

        #endregion

        #region Unity Methods

        private void Update()
        {
            CheckForEndScreen();           
        }

        private void OnEnable()
        {
            
        }

        #endregion
    }
}