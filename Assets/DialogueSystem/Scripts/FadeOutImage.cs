using GAD210.P2.Iteration1.Player;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutImage : MonoBehaviour
{
    #region Static Declaration

    public static FadeOutImage instance;

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

    private bool _isFading;
    public bool IsFading { get {  return _isFading; } }

    [Header("Timer")]

    [Space(5)]

    [SerializeField] private float delayBetweenFadeOutAmount;

    #endregion

    #region Methods

    public IEnumerator FadeOut(Image fadeImage, byte transValue, byte fadeDuration)
    {
        fadeImage.gameObject.SetActive(true);

        yield return new WaitForSeconds(delayBetweenFadeOutAmount);

        _isFading = true;
        fadeImage.color = new Color32(255, 255, 255, transValue);

        while (_isFading)
        {
            transValue -= fadeDuration;
            fadeImage.color = new Color32(255, 255, 255, transValue);

            if (transValue <= 0)
            {
                _isFading = false;
            }

            yield return null;
        }
    }

    #endregion
}
