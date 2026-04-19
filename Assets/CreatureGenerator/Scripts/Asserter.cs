using UnityEngine;
using UnityEngine.Assertions;

namespace GAD210.P2.Iteration1.PackageCreatures
{
    public class Asserter : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _gameManager;

        [SerializeField] private GameObject _exitPrompter;

        [SerializeField] private GameObject _packageNameInputField;

        #endregion

        #region Methods

        private void Asserting()
        {
            Assert.IsTrue(_gameManager.activeInHierarchy == true);

            Assert.IsTrue(_exitPrompter.activeInHierarchy == true);

            if (GameManager.instance.IsOnPackageNameScreen == true)
            {
                Assert.IsTrue(_packageNameInputField.activeInHierarchy == true); // We depend on this for actually searching for functions so this must remain always active
            }
        }

        #endregion

        #region Unity Methods

        // Update is called once per frame
        void Update()
        {
            Asserting(); // Assert all over the place
        }

        #endregion
    }
}