using GAD210.P2.Iteration1.Player;
using System.Collections.Generic;
using UnityEngine;

namespace GAD210.P2.Iteration1.Environment
{
    public class InteractableCarCrash : Interactable
    {
        #region Variables

        [TextArea]
        [SerializeField] private List<string> _affirmativeInteractText = new List<string>();

        [TextArea]
        [SerializeField] private List<string> _deniedInteractInpupText = new List<string>();

        [TextArea]
        [SerializeField] private List<string> _deniedInteractJawsOfLifeText = new List<string>();

        private int _affirmativeInteractTextIndex = 0;

        private int _deniedInteractInpupTextIndex = 0;

        private int _deniedInteractJawsOfLifeTextIndex = 0;

        [SerializeField] private GameObject _jawsOfLifeMicrogame;

        #endregion

        #region Unity Methods

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (CheckIfSelector(other) == true)
            {
                if (PlayerPackageCreatureManager.instance.HasInpup == true && PlayerItemManager.instance.HasJawsOfLife == true)
                {
                    if (_affirmativeInteractTextIndex < _affirmativeInteractText.Count - 1)
                    {
                        //Debug.Log("Display sign text!");
                        _textBoxDisplayer.Parse(_affirmativeInteractText[_affirmativeInteractTextIndex]);
                        _affirmativeInteractTextIndex++;
                    }
                    else
                    {
                        _jawsOfLifeMicrogame.SetActive(true);

                        _textBoxDisplayer.HideTextbox();
                        _affirmativeInteractTextIndex = 0;
                    }
                }
                else if (PlayerPackageCreatureManager.instance.HasInpup == false)
                {
                    if (_deniedInteractInpupTextIndex < _deniedInteractInpupText.Count - 1)
                    {
                        _textBoxDisplayer.Parse(_deniedInteractInpupText[_deniedInteractInpupTextIndex]);
                        _deniedInteractInpupTextIndex++;
                    }
                    else
                    {
                        _textBoxDisplayer.HideTextbox();
                        _deniedInteractInpupTextIndex = 0;
                    }
                }
                else if (PlayerItemManager.instance.HasJawsOfLife == false)
                {
                    if (_deniedInteractJawsOfLifeTextIndex < _deniedInteractJawsOfLifeText.Count - 1)
                    {
                        _textBoxDisplayer.Parse(_deniedInteractJawsOfLifeText[_deniedInteractJawsOfLifeTextIndex]);
                        _deniedInteractJawsOfLifeTextIndex++;
                    }
                    else
                    {
                        _textBoxDisplayer.HideTextbox();
                        _deniedInteractJawsOfLifeTextIndex = 0;
                    }
                }
            }
        }

        private void Start()
        {
            _jawsOfLifeMicrogame.SetActive(false);
        }

        #endregion
    }
}