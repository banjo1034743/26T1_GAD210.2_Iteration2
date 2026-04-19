using GAD210.P2.Iteration1.Player;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace GAD210.P2.Iteration1.Shop
{
    public class ShopManager : MonoBehaviour
    {
        #region Variables

        [Header("Shop Menu")]

        [Space(5)]

        [SerializeField] private Button _firstSelectedButton;

        [SerializeField] private Button _insuffecientFundsWindow;

        [SerializeField] private Button _sucessfulPurchaseWindow;

        [SerializeField] private GameObject _outOfStockIconJawsOfLife;

        [SerializeField] private GameObject _outOfStockIconSandwich;

        [Header("Items")]

        [Space(5)]

        // Scriptable object list
        [SerializeField] private List<Item> _purchaseableItems = new List<Item>();

        [Header("Scripts")]

        [Space(5)]

        [SerializeField] private PlayerItemManager _playerItemManager;

        #endregion

        #region Methods

        public void OpenShop()
        {
            PlayerFreezer.instance.CantMove = true;

            PlayerFreezer.instance.CantInteract = true;

            _firstSelectedButton.Select();
        }

        public void CloseShop()
        {
            PlayerFreezer.instance.CantMove = false;

            PlayerFreezer.instance.CantInteract = false;
        }

        public void PurchaseItem(string itemName)
        {
            switch (itemName)
            {
                case "JawsOfLife":
                    if (QueryAllowablePurchase(0) == true)
                    {
                        PlayerMoneyManager.instance.UpdateMoney(-_purchaseableItems[0].ItemPrice); // - to subtract from player money

                        PlayerItemManager.instance.HasJawsOfLife = true;

                        PlayerItemManager.instance.DisplayItemIcon(_purchaseableItems[0].ItemSprite);

                        DisplaySucessfulPurchaseWindow();

                        EnvironmentSoundPlayer.instance.PlaySFXClipAt("Money", _sucessfulPurchaseWindow.transform.position, 1, false);
                        
                        _outOfStockIconJawsOfLife.SetActive(true);
                    }
                    else
                    {
                        DisplayInsuffecientFundsWindow();

                        EnvironmentSoundPlayer.instance.PlaySFXClipAt("Failure", _insuffecientFundsWindow.transform.position, 1, false);
                    }
                    break;
                case "Sandwich":
                    if (QueryAllowablePurchase(1) == true)
                    {
                        PlayerMoneyManager.instance.UpdateMoney(-_purchaseableItems[1].ItemPrice); // - to subtract from player money

                        PlayerItemManager.instance.DisplayItemIcon(_purchaseableItems[1].ItemSprite);

                        DisplaySucessfulPurchaseWindow();
                    }
                    else
                    {
                        DisplayInsuffecientFundsWindow();
                    }
                    break;
                case "PackageCreatureGenerator":
                    if (QueryAllowablePurchase(2) == true)
                    {
                        Debug.Log("What- How did you get that much money? Oh my goodness the prototypes broken now oh no oh god");
                    }
                    else
                    {
                        DisplayInsuffecientFundsWindow();
                        EnvironmentSoundPlayer.instance.PlaySFXClipAt("Failure", _insuffecientFundsWindow.transform.position, 1, false);
                    }
                    break;
                default:
                    Debug.Log("Item is not recognised");
                    break;
            }
        }

        public void DisplaySucessfulPurchaseWindow()
        {
            _sucessfulPurchaseWindow.gameObject.SetActive(true);

            _sucessfulPurchaseWindow.Select();
        }

        public void DisplayInsuffecientFundsWindow()
        {
            _insuffecientFundsWindow.gameObject.SetActive(true);

            _insuffecientFundsWindow.Select();
        }

        private bool QueryAllowablePurchase(int itemIndex)
        {
            if (_purchaseableItems[itemIndex].ItemPrice <= PlayerMoneyManager.instance.PlayerMoney)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Unity Methods



        #endregion
    }
}