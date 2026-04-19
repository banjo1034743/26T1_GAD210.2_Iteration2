using UnityEngine;

[CreateAssetMenu(fileName = "TimeBeforeStarting", menuName = "Scriptable Objects/TimeBeforeStarting")]
public class TimeBeforeStarting : ScriptableObject
{
    public float ElapsedTime { get { return _elapsedTime; } set { _elapsedTime = value; } }
    
    private float _elapsedTime;
}
