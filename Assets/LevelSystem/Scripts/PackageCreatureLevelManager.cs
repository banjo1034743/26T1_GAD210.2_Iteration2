using UnityEngine;
using TMPro;

namespace GAD210.P2.Iteration1.PackageCreatures
{
    public class PackageCreatureLevelManager : MonoBehaviour
    {
        #region Static Declaration

        public static PackageCreatureLevelManager instance;

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

        [Header("Package Creature Level")]

        [SerializeField] private TextMeshProUGUI _packageCreatureLevelText;

        #endregion

        #region Methods

        public void UpdateLevel(PackageCreature currentPackageCreature, int amountToUpdateBy)
        {
            currentPackageCreature.PackageCreatureLevel += amountToUpdateBy;
        }

        public void ToggleLevelText(bool value)
        {
            _packageCreatureLevelText.gameObject.SetActive(value);
        }

        private void ResetEnergy()
        {
            _packageCreatureLevelText.text = "<b>Level: </b>" + PlayerPackageCreatureManager.instance.CurrentPackageCreature.PackageCreatureLevel.ToString();
        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            ResetEnergy();

            ToggleLevelText(false);
        }

        // Update is called once per frame
        void Update()
        {

        }

        #endregion
    }
}