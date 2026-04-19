using GAD210.P2.Iteration1.Player;
using TMPro;
using UnityEngine;

namespace GAD210.P2.Iteration1.Shop
{
    public class PlayerMoneyManager : MonoBehaviour
    {
        #region Static Declaration

        public static PlayerMoneyManager instance;

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

        [Header("Money")]

        [Space(5)]

        [SerializeField] private float _playerMoney;

        [SerializeField] private float _startingMoney;

        public float PlayerMoney {  get { return _playerMoney; } }

        [Header("HUD Elements")]

        [Space(5)]

        [SerializeField] private TextMeshProUGUI _moneyAmountText;

        #endregion

        #region Methods

        public void UpdateMoney(float amountToChangeBy)
        {
            _playerMoney += amountToChangeBy;

            _moneyAmountText.text = "Money: $" + _playerMoney.ToString();
        }

        private void InitialiseVariables()
        {
            _playerMoney = _startingMoney;

            _moneyAmountText.text = "Money: $" + _playerMoney.ToString();
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            InitialiseVariables();
        }

        #endregion
    }
}