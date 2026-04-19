using UnityEngine;

public class InputRecorder : MonoBehaviour
{
    #region Variables

    [SerializeField] private float _elapsedTime;

    #endregion

    #region Methods

    private void RecordTimeUntilStarting()
    {
        _elapsedTime = Time.realtimeSinceStartup;
    }

    #endregion

    #region Unity Methods

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    #endregion
}
