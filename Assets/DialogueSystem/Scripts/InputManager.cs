using UnityEngine;
using UnityEngine.InputSystem;

namespace GAD210.P2.Iteration1.DialogueSystem
{
    public class InputManager : MonoBehaviour
    {
        #region Variables

        [Header("Input System")]

        [SerializeField] private InputActionAsset _inputActions;

        private InputAction _interactAction;

        [Header("Exit Prompt")]

        [SerializeField] private GameObject _exitPromptWindow;

        #endregion

        #region Methods

        public bool HasContinuedDialogue()
        {
            return _interactAction.WasPerformedThisFrame();
        }

        private void InitialiseVariables()
        {
            _interactAction = _inputActions.FindAction("Player/Interact");

            //if (_interactAction != null)
            //{
            //    Debug.Log("Interact Action is not null");
            //}
        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            InitialiseVariables();
        }

        private void Update()
        {
            HasContinuedDialogue();
        }

        void OnEnable()
        {
            _inputActions.Enable();
        }

        void OnDisable()
        {
            _inputActions.Disable();
        }

        #endregion
    }
}