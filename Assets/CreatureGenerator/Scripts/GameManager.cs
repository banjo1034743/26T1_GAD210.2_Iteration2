using UnityEngine;

namespace GAD210.P2.Iteration1.PackageCreatures
{
    public class GameManager : MonoBehaviour
    {
        #region Static Declaration

        public static GameManager instance;

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

        public bool IsOnPackageNameScreen { get { return _isOnPackageNameScreen; } set { _isOnPackageNameScreen = value; } }

        [SerializeField] private GameObject _packageNameScreen;

        public bool IsOnCreatureGeneratorScreen { get { return _isOnCreatureGeneratorScreen; } set { _isOnCreatureGeneratorScreen = value; } }

        [SerializeField] private GameObject _creatureGeneratorScreen;

        private bool _isOnPackageNameScreen;

        private bool _isOnCreatureGeneratorScreen;

        [SerializeField] private CreatureGenerator _creatureGenerator;

        #endregion

        #region Variables

        private void SwitchToCreatureGenerator()
        {
            if (_isOnPackageNameScreen == false)
            {
                _packageNameScreen.SetActive(false);

                _creatureGeneratorScreen.SetActive(true);

                _isOnCreatureGeneratorScreen = true;
            }
        }

        public void SwitchToPackageName()
        {
            if (_isOnCreatureGeneratorScreen == false)
            {
                _packageNameScreen.SetActive(true);

                _creatureGenerator.ResetVariables();

                _creatureGeneratorScreen.SetActive(false);

                _isOnPackageNameScreen = true;
            }
        }

        private void InitialiseGame()
        {
            _isOnPackageNameScreen = true;

            _isOnCreatureGeneratorScreen = false;
        }

        #endregion

        #region Unity Methods

        private void Update()
        {
            SwitchToCreatureGenerator();
            SwitchToPackageName();
        }

        private void Start()
        {
            InitialiseGame();
        }

        #endregion
    }
}