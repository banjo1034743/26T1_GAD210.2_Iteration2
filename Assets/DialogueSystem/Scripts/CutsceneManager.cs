using GAD210.P2.Iteration1.Microgame;
using GAD210.P2.Iteration1.Player;
using UnityEngine;
using UnityEngine.UI;

namespace GAD210.P2.Iteration1.DialogueSystem
{
    public class CutsceneManager : MonoBehaviour
    {
        #region Static Declaration

        public static CutsceneManager instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        #endregion

        #region Variables

        [Header("Game Objects")]

        [Space(5)]

        [SerializeField] private GameObject _arnoldCutsceneObject;

        [SerializeField] private GameObject _policeOfficerCutsceneObject;
        public GameObject PoliceOfficerCutsceneObject { get { return _policeOfficerCutsceneObject; } }

        [SerializeField] private GameObject _winScreen;

        [SerializeField] private Button _exitGameButton;

        // Cutscenes

        private const int _policeOfficerCutscene = 0;
        public int PoliceOfficerCutscene { get { return _policeOfficerCutscene; } }

        private const int _arnoldCutscene = 1;
        public int ArnoldCutscene { get { return _arnoldCutscene; } }

        [Header("Scripts")]

        [Space(5)]

        [SerializeField] private TextParser _textParser;

        #endregion

        #region Methods

        public void EnableCutscene(int cutscene)
        {
            PlayerFreezer.instance.CantMove = true;

            PlayerFreezer.instance.CantInteract = true;

            _textParser.SetIsActiveValue(true);

            switch (cutscene)
            {
                case 0:
                    _policeOfficerCutsceneObject.SetActive(true);
                    break;
                case 1:
                    _arnoldCutsceneObject.SetActive(true);
                    break;
            }
        }

        private void CheckForEndScreen()
        {
            //if (_textParser.CurrentDialogueLine >= _textParser.AmountOfDialogueLines && _textParser.AmountOfDialogueLines != 0) // Hack but whatever
            //{
            //    if (_winScreen.activeSelf == false)
            //    {
            //        _winScreen.SetActive(true);
            //        _exitGameButton.Select();

            //        EnvironmentSoundPlayer.instance.PlaySFXClipAt("Victory Horn", _winScreen.transform.position, 1, false);
            //        EnvironmentSoundPlayer.instance.PlaySFXClipAt("Party Horn", _winScreen.transform.position, 1, false);
            //        EnvironmentSoundPlayer.instance.PlaySFXClipAt("Child Cheer", _winScreen.transform.position, 1, false);
            //    }
            //}
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