using UnityEngine;
using UnityEngine.InputSystem;

namespace GAD210.P2.Iteration1.Player
{
    public class InputManager : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        public Vector2 direction;

        protected float buttonFloat;

        public bool InteractButtonPressed { get { return buttonBool; } }
        protected bool buttonBool;

        protected float escapeFloat;
        protected bool escapeBool;

        #endregion

        #region Methods

        public virtual void Movement(InputAction.CallbackContext context)
        {
            if (PlayerFreezer.instance.CantMove == false)
            {
                direction = context.ReadValue<Vector2>();
                Debug.Log(direction);
            }
            else
            {
                direction = Vector2.zero;
            }
        }

        public virtual void Interact(InputAction.CallbackContext context)
        {
            if (PlayerFreezer.instance.CantInteract == false)
            {
                if (context.performed)
                {
                    buttonBool = true;
                }
                else if (context.canceled)
                {
                    buttonBool = false;
                }
            }
            else
            {
                buttonBool = false;
            }
        }

        public virtual void Escape(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("player");
                escapeBool = true;
            }
            else if (context.canceled)
            {
                escapeBool = false;
            }
        }

        public Vector2 GetDirectionValue()
        {
            return direction;
        }

        public bool GetEscapeBoolValue()
        {
            return escapeBool;
        }

        #endregion
    }
}