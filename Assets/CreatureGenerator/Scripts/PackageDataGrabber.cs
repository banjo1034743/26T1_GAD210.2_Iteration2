using UnityEngine;
using TMPro;

namespace GAD210.P2.Iteration1.PackageCreatures
{
    public class PackageDataGrabber : MonoBehaviour
    {
        #region Variables

        #region Package Creature Const Int Values

        private const int Inpup = 0;

        #endregion

        private bool _hasGrabbedPackageData = false;

        [Header("Components")]

        [SerializeField] private TMP_InputField _inputField;

        [Header("Scripts")]

        [SerializeField] private CreatureGenerator creatureGenerator;

        #endregion

        #region Methods

        public void GetPackage(string packageName)
        {
            switch (packageName)
            {
                //case "com.unity.2d.animation":
                //    creatureGenerator.CreateCreature("Unity Technologies", "2D Animation", 2025);
                //    _hasGrabbedPackageData = true;
                //    break;
                //case "2D Animation":
                //    _hasGrabbedPackageData = true;
                //    break;
                //case "com.unity.services.analytics":
                //    creatureGenerator.CreateCreature("Unity Technologies", "Analytics", 2026);
                //    _hasGrabbedPackageData = true;
                //    break;
                //case "Analytics":
                //    break;
                case "com.unity.inputsystem":
                    creatureGenerator.CreateCreature(Inpup);
                    _hasGrabbedPackageData = true;
                    break;
                case "Input System":
                    creatureGenerator.CreateCreature(Inpup);
                    _hasGrabbedPackageData = true;
                    break;
                default:
                    Debug.Log("This package is not recognised by the prototype. Ensure it has been spelt correctly and are under the 'Released packages' section in the documentation");
                    _inputField.text = "This package is not recognised by the prototype. Ensure it has been spelt correctly and are under the 'Released packages' section in the documentation";
                    break;
            }

            if (_hasGrabbedPackageData == true)
            {
                //GameManager.instance.IsOnPackageNameScreen = false; // Tells GameManager to switch screens
                _hasGrabbedPackageData = false;
            }
        }

        private void InitialisrVariables()
        {

        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            InitialisrVariables();
        }

        #endregion
    }
}