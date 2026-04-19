using GAD210.P2.Iteration1.Shop;
using UnityEngine;

namespace GAD210.P2.Iteration1.Environment
{
    public class InteractableShop : Interactable
    {
        #region Variables

        [Header("Shop")]

        [Space(5)]

        [SerializeField] private GameObject _shopScreen;

        [SerializeField] private ShopManager _shopManager;

        #endregion

        #region Unity Methods

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (CheckIfSelector(other) == true)
            {
                _shopScreen.SetActive(true);
                _shopManager.OpenShop();
            }
        }

        #endregion
    }
}