using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GAD210.P2.Iteration1.DialogueSystem
{
    public class UIManager : MonoBehaviour
    {
        #region Variables

        [Header("Arnold")]

        [Space(5)]

        [SerializeField] private Image _arnoldImage;

        [SerializeField] private float _amountToMoveArnoldBy;

        [Header("Name Query")]

        [Space(5)]

        [SerializeField] private GameObject _textElements;

        [SerializeField] private GameObject _inputFieldElements;

        [SerializeField] private TMP_InputField _inputField;

        [Header("Yes Query")]

        [Space(5)]

        [SerializeField] private GameObject _buttonPromptElements;

        [SerializeField] private Button _buttonPromptButton;

        [Header("Player Profile Picture")]

        [Space(5)]

        [SerializeField] private Image _cameraFlashElement;

        [SerializeField] private RawImage _playerProfilePictureDisplay;

        [SerializeField] private GameObject _playerPhotoTaker;

        [Header("Timer")]

        [Space(5)]

        [SerializeField] private float delayBetweenFadeOutAmount;

        private Timer _delayBetweenFadeOutTimer;

        #endregion

        #region Methods

        public void ToggleTextElements(bool value)
        {
            _textElements.SetActive(value);
        }

        public void ToggleInputField(bool value)
        {
            _inputFieldElements.SetActive(value);

            if (value == true)
            {
                _inputField.ActivateInputField();
            }
        }

        public void ToggleButtonPrompt(bool value)
        {
            _buttonPromptElements.SetActive(value);

            if (value == true)
            {
                _buttonPromptButton.Select();
            }
        }

        private void TogglePlayerProfileImage(bool value)
        {
            _playerPhotoTaker.SetActive(false);

            _playerProfilePictureDisplay.gameObject.SetActive(value);
        }

        public void PlayCameraFlash()
        {
            StartCoroutine(FadeOutImage.instance.FadeOut(_cameraFlashElement, 255, 1));

            RearrangeArnold();

            _playerPhotoTaker.SetActive(true);
        }

        private void RearrangeArnold()
        {
            _playerProfilePictureDisplay.gameObject.SetActive(true);

            _arnoldImage.gameObject.transform.Translate(_amountToMoveArnoldBy, 0, 0);
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            ToggleInputField(false);

            ToggleButtonPrompt(false);

            //TogglePlayerProfileImage(false);

            ToggleTextElements(true);
        }

        #endregion
    }
}