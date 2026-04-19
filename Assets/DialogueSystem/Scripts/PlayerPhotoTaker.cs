using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

namespace GAD210.P2.Iteration1.DialogueSystem
{
    public class PlayerPhotoTaker : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerPhotoHandler _playerPhotoHandler;

        [SerializeField] private RawImage _playerProfilePhoto;

        [SerializeField] private RenderTexture _playerPhotoTexture;

        [SerializeField] private Image _testImage;

        private WebCamTexture _webCam;

        private Color32[] _rawPlayerPhotoData; 

        #endregion

        #region Methods

        private void SetPlayerProfileImage()
        {
            RenderTexture.active = _playerPhotoTexture;

            _webCam = new WebCamTexture();

            _playerProfilePhoto.texture = _webCam;

            _webCam.Play();

            StartCoroutine(InvokePhotoTaking());
        }

        private IEnumerator InvokePhotoTaking()
        {
            yield return new WaitForEndOfFrame();

            Texture2D texture = new Texture2D(_playerProfilePhoto.texture.width, _playerProfilePhoto.texture.height);
            texture.ReadPixels(new Rect(_playerProfilePhoto.rectTransform.rect.x, _playerProfilePhoto.rectTransform.rect.y, _playerProfilePhoto.rectTransform.rect.width, _playerProfilePhoto.rectTransform.rect.height), 0, 0);
            texture.Apply();

            yield return new WaitForSeconds(0.2f);

            Sprite playerPic = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f, 100); // Vector2.one * 0.5 = fancy way of making pivot in center
            _testImage.sprite = playerPic;

            //=== ORIGINAL CODE ===

            //yield return new WaitForEndOfFrame();

            //_rawPlayerPhotoData = _webCam.GetPixels32();

            // Source - https://stackoverflow.com/a/58682603
            // Posted by derHugo, modified by community. See post 'Timeline' for change history
            // Retrieved 2026-04-14, License - CC BY-SA 4.0

            //var texture = new Texture2D(_webCam.width, _webCam.height);
            //texture.SetPixels32(_rawPlayerPhotoData);
            //texture.Apply();

            // yield return new WaitForSeconds(0.2f);

            //Sprite playerPic = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f, 100);
            //_playerPhotoHandler.PlayerProfileImage = playerPic;

            //_testImage.sprite = playerPic;

            //_webCam.Stop();

            //gameObject.SetActive(false);
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            SetPlayerProfileImage();
        }

        #endregion
    }
}