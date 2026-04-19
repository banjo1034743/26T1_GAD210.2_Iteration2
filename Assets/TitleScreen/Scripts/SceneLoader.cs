using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GAD210.P2.Iteration1.SceneLoaderNamespace
{
    public class SceneLoader : MonoBehaviour
    {
        #region Variables

        private float _elapsedTime = 0;

        [SerializeField] private TimeBeforeStarting _timeBeforeStarting;

        [SerializeField] private Button _startButton;

        #endregion

        #region Methods

        public void LoadScene(int indexOfScene)
        {
            Debug.Log("Loading scene!");
            SceneManager.LoadScene(indexOfScene);
        }

        public void SetTimeBeforeStarting()
        {
            _timeBeforeStarting.ElapsedTime = _elapsedTime;
        }

        private void UpdateTimeBeforeStartingCount()
        {
            _elapsedTime += Time.deltaTime;
        }

        private void InitialiseVariables()
        {
            if (SceneManager.GetActiveScene().name == "TitleScreen")
            {
                _startButton.Select();
            }
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            InitialiseVariables();
        }

        private void Update()
        {
            UpdateTimeBeforeStartingCount();
        }

        #endregion
    }
}