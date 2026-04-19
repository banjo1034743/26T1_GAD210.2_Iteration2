using GAD210.P2.Iteration1.Player;
using GAD210.P2.Iteration1.Shop;
using UnityEngine;
using UnityEngine.UI;

namespace GAD210.P2.Iteration1.Microgame
{
    public class JawsOfLifeManager : MicrogameManager
    {
        #region Variables

        [Header("Microgame UI")]

        [Space(5)]

        [SerializeField] private GameObject _jawsOfLifeUI;

        [SerializeField] private Slider _jawsOfLifeSlider;

        [SerializeField] private Button _jawsOfLifeButton;

        [Header("Microgame Parameters")]

        [Space(5)]

        [SerializeField] private float _sliderStartingValue;

        [SerializeField] private float _sliderIncreaseAmount;

        [SerializeField] private float _sliderDecreaseSpeed;

        [SerializeField] private float _delayBetweenWinDuration;

        [Header("Scripts")]

        [Space(5)]

        [SerializeField] private CarCrashManager _carCrashManager;

        //---

        private Timer delayBetweenWinTimer;

        #endregion

        #region Methods

        // Called by hidden button player presses
        public void IncreaseSliderValue()
        {
            if (_hasWon == false)
            {
                _jawsOfLifeSlider.value += _sliderIncreaseAmount;

                EnvironmentSoundPlayer.instance.PlaySFXClipAt("Metal Creak", _jawsOfLifeSlider.transform.position, 1, true);
            }
        }

        private void DecreaseSliderValue()
        {
            if (_hasWon == false)
            {
                if (_jawsOfLifeSlider.value > 0)
                {
                    _jawsOfLifeSlider.value = Mathf.Lerp(_jawsOfLifeSlider.value, 0, _sliderDecreaseSpeed);
                }
            }
        }

        private void CheckIfWon()
        {
            if (_hasWon == false)
            {
                if (_jawsOfLifeSlider.value > 0.95f)
                {
                    // Play SFX
                    EnvironmentSoundPlayer.instance.PlaySFXClipAt("Success", _jawsOfLifeSlider.transform.position, 1, false);

                    _hasWon = true;

                    delayBetweenWinTimer.Restart();
                }
            }
        }

        private void CheckForClosingMicrogame()
        {
            if (_hasWon == true && delayBetweenWinTimer.HasExpired == true)
            {
                _carCrashManager.EnableIncidentCompletionWindow();
                PlayerMoneyManager.instance.UpdateMoney(10);

                _jawsOfLifeUI.SetActive(false);
            }
        }

        private void InitializeMicrogame()
        {
            PlayerFreezer.instance.CantMove = true;

            PlayerFreezer.instance.CantInteract = true;

            _jawsOfLifeSlider.value = _sliderStartingValue;

            delayBetweenWinTimer.Duration = 1f;

            _jawsOfLifeButton.Select();
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            InitializeMicrogame();
        }

        protected override void Update()
        {
            DecreaseSliderValue();

            CheckIfWon();
            CheckForClosingMicrogame();
        }

        #endregion
    }
}