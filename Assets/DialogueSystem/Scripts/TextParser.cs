using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GAD210.P2.Iteration1.DialogueSystem
{
    public class TextParser : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int currentDialogueLine = 0;
        public int CurrentDialogueLine { get { return currentDialogueLine; } }

        [SerializeField] private int amountOfDialogueLines;
        public int AmountOfDialogueLines { get { return amountOfDialogueLines; } }

        [TextArea]
        [SerializeField] private List<string> dialogueLines = new List<string>();

        public TextMeshProUGUI dialogueText;
        public TextMeshProUGUI nameText;
        [SerializeField] private float timeBtwnChars;

        public GameObject dialogueBackground;

        [SerializeField] private GameObject _textElements;

        public bool isActive;

        [Header("Scripts")]

        [Space(5)]

        [SerializeField] private InputManager _dialogueSystemInputManager;

        [SerializeField] private TimeBeforeStarting _timeBeforeStarting;

        [SerializeField] private UIManager _dialogueUIManager;

        [SerializeField] private NameSaver _nameSaver;

        //--

        [Header("Timer Parameters")]

        [Space(5)]

        [SerializeField] private float _delayTimeBeforeCameraFlash;

        private bool _calledCameraFlashTimer = false;

        private bool _waitingForFadeOut = false;

        private Timer _delayBeforeCameraFlashTimer;

        //[SerializeField] private float _delayTimeBeforeFadingOut;

        //private Timer _delayBeforeFadingOutTimer;

        #endregion

        #region Methods

        private void InitialiseScript()
        {
            Debug.Log("Starting cutscene!");

            // Start with first line of dialogue
            currentDialogueLine = 0;

            // Set the value so that we dont call an error when at the last
            amountOfDialogueLines = dialogueLines.Capacity;
            amountOfDialogueLines -= 1;

            isActive = true;
            //Debug.Log(currentDialogueLine);

            // Set the durations of the timers
            _delayBeforeCameraFlashTimer.Duration = _delayTimeBeforeCameraFlash;
            //_delayBeforeFadingOutTimer.Duration = _delayTimeBeforeFadingOut;

            // Initialise text with first line
            Parse();
        }

        public void ParseDialogueOnInput(bool cutsceneForceParse)
        {
            if (isActive)
            {
                if (_dialogueSystemInputManager.HasContinuedDialogue() == true || cutsceneForceParse == true)
                {
                    currentDialogueLine++;

                    if (currentDialogueLine <= amountOfDialogueLines)
                    {
                        //currentDialogueLine++;
                        Parse();
                    }
                }
            }
        }

        public void SetIsActiveValue(bool value)
        {
            isActive = value;
        }

        private void Parse()
        {
            Debug.Log("We've parsed");

            CheckForSpecialCommands(dialogueLines[currentDialogueLine]);

            if (isActive)
            {
                dialogueText.text = dialogueLines[currentDialogueLine];

                StartCoroutine(MakeTextVisible());
            }
        }

        private IEnumerator MakeTextVisible()
        {
            dialogueText.ForceMeshUpdate();
            int totalVisibleChars = dialogueText.textInfo.characterCount;
            int counter = 0;

            while (true)
            {
                int visibleCount = counter % (totalVisibleChars + 1);
                dialogueText.maxVisibleCharacters = visibleCount;

                if (visibleCount >= totalVisibleChars)
                {
                    break;
                }

                counter += 1;
                yield return new WaitForSeconds(timeBtwnChars);
            }
        }

        #endregion

        #region Special Commands

        private void CheckForSpecialCommands(string dialogue)
        {
            if (dialogue.Contains("TimeBeforeStarting"))
            {
                Debug.Log("TimeBeforeStarting");
                if (_timeBeforeStarting.ElapsedTime == 1)
                {
                    string elapsedTime = _timeBeforeStarting.ElapsedTime.ToString() + " second";
                    dialogueLines[currentDialogueLine] = dialogue.Replace("TimeBeforeStarting", elapsedTime);
                }
                else if (_timeBeforeStarting.ElapsedTime > 1 || _timeBeforeStarting.ElapsedTime <= 1)
                {
                    string elapsedTime = _timeBeforeStarting.ElapsedTime.ToString() + " seconds";
                    dialogueLines[currentDialogueLine] = dialogue.Replace("TimeBeforeStarting", elapsedTime);
                }
            }
            else if (dialogue.Contains("UserName"))
            {
                dialogueLines[currentDialogueLine] = dialogue.Replace("UserName", System.Environment.UserName);
            }
            else if (dialogue.Contains("InputField"))
            {
                _dialogueUIManager.ToggleTextElements(false);
                _dialogueUIManager.ToggleInputField(true);

                isActive = false;
            }
            else if (dialogue.Contains("InputtedName"))
            {
                dialogueLines[currentDialogueLine] = dialogue.Replace("InputtedName", _nameSaver.PlayerName);
            }
            else if (dialogue.Contains("ButtonPrompt"))
            {
                _dialogueUIManager.ToggleTextElements(false);
                _dialogueUIManager.ToggleButtonPrompt(true);

                isActive = false;
            }
            else if (dialogue.Contains("PlayerProfilePicture"))
            {
                Debug.Log("Text contains PlayerProfilePicture");

                isActive = false;

                dialogueLines[currentDialogueLine] = dialogue.Replace("PlayerProfilePicture", "");

                dialogueText.text = dialogueLines[currentDialogueLine];

                StartCoroutine(MakeTextVisible());

                _delayBeforeCameraFlashTimer.Restart();

                _calledCameraFlashTimer = true;
            }
        }

        private void CheckIfCanCameraFlash()
        {
            if (_calledCameraFlashTimer == true && _delayBeforeCameraFlashTimer.HasExpired == true)
            {
                Debug.Log("Met the conditions to Camera Flash");

                _calledCameraFlashTimer = false;

                _dialogueUIManager.PlayCameraFlash();

                _waitingForFadeOut = true;
            }
        }


        private void CheckIfCanContinueDialogueAfterFadeOut()
        {
            if (_waitingForFadeOut == true && FadeOutImage.instance.IsFading == false) // Check for bool so this isn't called early
            {
                Debug.Log("Met the conditions to continue dialogue");
                _waitingForFadeOut = false;
                isActive = true;

                ParseDialogueOnInput(true);
            }
        }

        #endregion

        #region Unity Methods

        void Awake()
        {
            InitialiseScript();
        }

        void Update()
        {
            ParseDialogueOnInput(false);

            CheckIfCanCameraFlash();
            CheckIfCanContinueDialogueAfterFadeOut();
        }

        #endregion
    }
}