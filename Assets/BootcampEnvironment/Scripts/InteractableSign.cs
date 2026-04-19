using UnityEngine;
using System.Collections.Generic;

namespace GAD210.P2.Iteration1.Environment
{
    public class InteractableSign : Interactable
    {
        #region Variables

        [TextArea]
        [SerializeField] private List<string> _signText = new List<string>();

        private int _signTextIndex = 0;

        #endregion

        #region Unity Methods

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("We've triggered");

            if (CheckIfSelector(other) == true)
            {
                if (_signTextIndex < _signText.Count - 1)
                {
                    Debug.Log("Display sign text!");
                    _textBoxDisplayer.Parse(_signText[_signTextIndex]);
                    _signTextIndex++;
                }
                else
                {
                    _textBoxDisplayer.HideTextbox();
                    _signTextIndex = 0;
                }
            }
        }

        #endregion
    }
}