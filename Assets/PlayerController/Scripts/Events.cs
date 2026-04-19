using UnityEngine;

namespace GAD210.P2.Iteration1.Player
{
    public class Events : MonoBehaviour
    {
        #region Singleton Delcaration

        public static Events instance = null;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        #endregion

        #region Events


        #endregion
    }
}