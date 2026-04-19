using GAD210.P2.Iteration1.Microgame;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GAD210.P2.Iteration1
{
    public class PlayerPackageCreatureManager : MonoBehaviour
    {
        #region Static Declaration

        public static PlayerPackageCreatureManager instance;

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

        [Header("UI")]

        [Space(5)]

        [SerializeField] private Image _packageCreatureIcon;

        [SerializeField] private TextMeshProUGUI _levelText;

        [Header("Package Creatures")]

        [Space(5)]

        private PackageCreature _currentPackageCreature;

        [Header("Parameters")]

        [Space(5)]

        private bool _hasInpup;
        public bool HasInpup { get  { return _hasInpup; } }

        //[SerializeField] private List<PackageCreature> _packageCreatureList = new List<PackageCreature>();

        #endregion

        #region Methods

        public void SetPackageCreatureAsPlayers(PackageCreature packageCreature)
        {
            _packageCreatureIcon.sprite = packageCreature.PackageCreatureDisplayImage;
            _packageCreatureIcon.gameObject.SetActive(true);

            _currentPackageCreature = packageCreature;
            _levelText.gameObject.SetActive(true);

            // Specifically doing Inpup here for sake of prototype. Would be set to specitc package creature normally
            _hasInpup = true;
        }

        public void UpdateLevelText(string updatedText)
        {
            _levelText.text = updatedText;
        }

        private void InitialiseVariables()
        {
            _packageCreatureIcon.sprite = null;
        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            InitialiseVariables();
        }

        // Update is called once per frame
        void Update()
        {

        }

        #endregion
    }
}