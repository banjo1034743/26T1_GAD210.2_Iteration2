using TMPro;
using UnityEngine;

namespace GAD210.P2.Iteration1.DialogueSystem
{
    public class NameSaver : MonoBehaviour
    {
        #region Variables

        public string PlayerName { get { return _playerName; } }

        [SerializeField] private string _playerName;

        #endregion

        #region Methods

        public void GetInputtedName(string name)
        {
            _playerName = name;
        }

        #endregion

        #region Unity Methods


        #endregion
    }
}