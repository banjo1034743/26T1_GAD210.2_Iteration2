using UnityEngine;

namespace GAD210.P2.Iteration1.Player
{
    public class PlayerFreezer : MonoBehaviour
    {
        #region Static Declaration

        public static PlayerFreezer instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        #endregion

        #region Variables

        // Will be used to make player not react to movement input when we want it to
        [SerializeField] private bool _cantMove;

        public bool CantMove { get { return _cantMove; } set { _cantMove = value; } }

        [SerializeField] private bool _cantInteract;

        public bool CantInteract { get { return _cantInteract; } set { _cantInteract = value; } }

        #endregion

        #region Methods

        private void InitialiseVariables()
        {
            _cantMove = false;
        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            InitialiseVariables();
        }

        #endregion
    }
}