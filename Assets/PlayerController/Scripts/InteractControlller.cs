using GAD210.P2.Iteration1.DialogueSystem;
using UnityEngine;

namespace GAD210.P2.Iteration1.Player
{
    public class InteractControlller : MonoBehaviour
    {
        #region Variables

        [Header("Selector")]

        [Space(5)]

        // Hitbox that's used to know which object is being interacted with
        [SerializeField] private GameObject _selector;

        [Tooltip("Enable this show the hitboxes for the select area when interacting")]
        [SerializeField] private bool _enableSprites;

        // Sprite for hitbox of Selector
        [SerializeField] private SpriteRenderer _selectorSprite;

        // Sprtie for area that selector will cover when pressing Interact button
        [SerializeField] private SpriteRenderer _selectorAreaSprite;

        [Header("Scripts")]

        [Space(5)]

        [SerializeField] private InputManager _inputManager;

        #endregion

        #region Methods

        private void Interact()
        {
            if (_inputManager.InteractButtonPressed == true)
            {
                ToggleSelector(true);
            }
            else
            {
                ToggleSelector(false);
            }
        }

        private void ToggleSelector(bool value)
        {
            _selector.SetActive(value);
        }

        // Ooops! Done in animator. I forgor
        //private void RotateSelectorWithPlayer()
        //{
        //    switch (_inputManager.GetDirectionValue().x)
        //    {
        //        case -1f:
        //            _selector.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90f));
        //            break;
        //        case 1f:
        //            _selector.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90f));
        //            break;
        //    }

        //    switch (_inputManager.GetDirectionValue().y)
        //    {
        //        case -1f:
        //            _selector.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -180f));
        //            break;
        //        case 1f:
        //            _selector.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0f));
        //            break;
        //    }
        //}

        private void InitialiseSelector()
        {
            if (_enableSprites == true)
            {
                _selectorSprite.enabled = true;
                _selectorAreaSprite.enabled = true;
            }

            _selector.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -180f));
            _selector.SetActive(false);
        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            InitialiseSelector();
        }

        // Update is called once per frame
        void Update()
        {
            Interact();
            //RotateSelectorWithPlayer();
        }

        #endregion
    }
}   