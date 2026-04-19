using System.Collections;
using UnityEngine;
using TMPro;

namespace GAD210.P2.Iteration1.Environment
{
    public class TextBoxDisplayer : MonoBehaviour
    {
        #region Variables

        [Header("Text Box")]

        [Space(5)]

        [SerializeField] private GameObject textBox;

        [SerializeField] private TextMeshProUGUI textBoxContents;

        [SerializeField] private float timeBtwnChars;

        #endregion

        #region Methods

        public void Parse(string dialogue)
        {
            textBox.SetActive(true);
            textBoxContents.text = dialogue;
            StartCoroutine(TextVisible());
        }

        public void HideTextbox()
        {
            textBoxContents.text = "";
            textBox.SetActive(false);
        }

        #endregion

        #region TextVisible

        private IEnumerator TextVisible()
        {
            textBoxContents.ForceMeshUpdate();
            int totalVisibleChars = textBoxContents.textInfo.characterCount;
            int counter = 0;

            while (true)
            {
                int visibleCount = counter % (totalVisibleChars + 1);
                textBoxContents.maxVisibleCharacters = visibleCount;

                if (visibleCount >= totalVisibleChars)
                {
                    break;
                }

                counter += 1;
                yield return new WaitForSeconds(timeBtwnChars);
            }
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            HideTextbox();
        }

        #endregion
    }
}