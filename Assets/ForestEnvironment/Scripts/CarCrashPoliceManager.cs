using GAD210.P2.Iteration1.DialogueSystem;
using GAD210.P2.Iteration1.Player;
using GAD210.P2.Iteration2.IncidentCompletionWindow;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

namespace GAD210.P2.Iteration1.Microgame
{
    public class CarCrashPoliceManager : MonoBehaviour
    {
        #region Static Declaration

        public static CarCrashPoliceManager instance;

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

        [Header("Components")]

        [Space(5)]

        [SerializeField] private Tilemap _tileMapWithCarCrash;

        [Header("Sprites")]

        [Space(5)]

        [SerializeField] private Sprite _carCrashSpriteClosed;
        public Sprite CarCrashSpriteClosed { get { return _carCrashSpriteClosed; } }

        [SerializeField] private Sprite _carCrashSpriteOpened;
        public Sprite CarCrashSpriteOpened { get { return _carCrashSpriteOpened; } }

        [Header("Data")]

        [Space(5)]

        [SerializeField] private bool _isOpened = false;
        public bool IsOpened { get { return _isOpened; } }

        [Header("Scripts")]

        [Space(5)]

        [SerializeField] private PlayerPackageCreatureManager _playerPackageCreatureManager;

        [SerializeField] private IncidentCompletionWindow _incidentCompletionWindow;

        [SerializeField] private TextParser _policeOfficerCutsceneTextParser;

        #endregion

        #region Methods

        public void UpdateCarCrash()
        {
            _isOpened = true;

            _tileMapWithCarCrash.RefreshAllTiles();
        }

        public void InitialiseCutscene()
        {
            _incidentCompletionWindow.InitialisePlayingCutscene(CutsceneManager.instance.PoliceOfficerCutscene);
        }

        private void Initialize()
        {
            _tileMapWithCarCrash.RefreshAllTiles();
        }

        private void CheckForEndOfCutscene() 
        {
            if (_policeOfficerCutsceneTextParser.CurrentDialogueLine >= _policeOfficerCutsceneTextParser.AmountOfDialogueLines && _policeOfficerCutsceneTextParser.isActive == true)
            {
                _policeOfficerCutsceneTextParser.SetIsActiveValue(false);

                PlayerFreezer.instance.CantMove = false;

                PlayerFreezer.instance.CantInteract = false;

                CutsceneManager.instance.PoliceOfficerCutsceneObject.SetActive(false);
            }
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            Initialize();
        }

        private void Update()
        {
            CheckForEndOfCutscene();
        }

        #endregion
    }
}