using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPhotoHandler", menuName = "Scriptable Objects/PlayerPhotoHandler")]
public class PlayerPhotoHandler : ScriptableObject
{
    [SerializeField] private Sprite _playerProfileImage = null;
    public Sprite PlayerProfileImage {  get { return _playerProfileImage; } set { _playerProfileImage = value; } } 
}
