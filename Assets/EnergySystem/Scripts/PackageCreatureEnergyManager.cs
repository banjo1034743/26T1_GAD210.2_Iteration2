using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace GAD210.P2.Iteration1.PackageCreatures
{
    public class PackageCreatureEnergyManager : MonoBehaviour
    {
        #region Static Declaration

        public static PackageCreatureEnergyManager instance;

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

        [Header("Energy")]

        [SerializeField] private TextMeshProUGUI _energyText;

        #endregion

        #region Methods

        public void UpdateEnergy(PackageCreature currentPackageCreature, int valueToUpdateBy)
        {
            currentPackageCreature.PackageCreatureEnergy += valueToUpdateBy;
            _energyText.text = "<b>Energy: </b>" + currentPackageCreature.PackageCreatureEnergy.ToString();
        }

        public void ToggleEnergyText(bool value)
        {
            _energyText.gameObject.SetActive(value);
        }

        private void ResetEnergy()
        {
            _energyText.text = "<b>Energy: </b>" + PlayerPackageCreatureManager.instance.CurrentPackageCreature.PackageCreatureEnergy.ToString();
        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            ResetEnergy();

            ToggleEnergyText(false);
        }

        #endregion
    }
}