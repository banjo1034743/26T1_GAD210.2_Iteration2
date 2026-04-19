using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace GAD210.P2.Iteration1.Player
{
    public class PlayerItemManager : MonoBehaviour
    {
        #region Static Declaration

        public static PlayerItemManager instance;

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

        [Header("HUD Elements")]

        [Space(5)]

        [SerializeField] private List<Image> _itemHUDIcons = new List<Image>();

        [Header("Jaws of Life")]

        [Space(5)]

        [SerializeField] private bool _hasJawsOfLife = false;

        public bool HasJawsOfLife { get {  return _hasJawsOfLife; } set { _hasJawsOfLife = value; } }

        #endregion

        #region Methods

        // Method for displaying icon on HUD for purchased items
        public void DisplayItemIcon(Sprite imageToDisplay)
        {
            foreach (Image icon in _itemHUDIcons)
            {
                if (icon.sprite == null)
                {
                    Debug.Log("Displaying image!");
                    icon.sprite = imageToDisplay;
                    return;
                }
            }
        }

        #endregion
    }
}