using System.Security.Authentication.ExtendedProtection;
using UnityEngine;

namespace GAD210.P2.Iteration1.Microgame
{
    public abstract class MicrogameManager : MonoBehaviour
    {
        #region Variables

        [SerializeField] protected bool _hasWon;

        #endregion

        #region Methods

        public virtual void ToggleMicrogame(bool value)
        {
            gameObject.SetActive(value);
        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        protected virtual void Awake()
        {

        }

        // Update is called once per frame
        protected virtual void Update()
        {

        }

        #endregion
    }
}