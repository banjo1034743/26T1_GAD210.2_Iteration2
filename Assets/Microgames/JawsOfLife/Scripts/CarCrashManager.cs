using GAD210.P2.Iteration1.Player;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

namespace GAD210.P2.Iteration1.Microgame
{
    public class CarCrashManager : MonoBehaviour
    {
        #region Static Declaration

        public static CarCrashManager instance;

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

        [Header("Stat Increase Window")]

        [SerializeField] private GameObject _completionWindowParent;

        [SerializeField] private Button _completionWindow;

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

        #endregion

        #region Methods

        public void EnableIncidentCompletionWindow()
        {
            _isOpened = true;

            _tileMapWithCarCrash.RefreshAllTiles();

            _completionWindowParent.SetActive(true);

            // Temportary implementation for sake of tutorial
            _playerPackageCreatureManager.UpdateLevelText("Level: 2");

            _completionWindow.Select();
        }

        private void Initialize()
        {
            _tileMapWithCarCrash.RefreshAllTiles();
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            Initialize();
        }

        #endregion
    }
}