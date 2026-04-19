using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GAD210.P2.Iteration1.DialogueSystem
{
    public class TextAnim : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI dialogueText;

        public string[] stringArray;

        [SerializeField] float timeBtwnChars;

        [SerializeField] float timeBtwnWords;

        int i = 0;

        // Start is called before the first frame update
        void Start()
        {
            EndCheck();
        }

        void EndCheck()
        {
            if (i <= stringArray.Length - 1)
            {
                dialogueText.text = stringArray[i];
                StartCoroutine(TextVisible());
            }
        }

        private IEnumerator TextVisible()
        {
            dialogueText.ForceMeshUpdate();
            int totalVisibleChars = dialogueText.textInfo.characterCount;
            int counter = 0;

            while (true)
            {
                int visibleCount = counter % (totalVisibleChars + 1);
                dialogueText.maxVisibleCharacters = visibleCount;

                if (visibleCount >= totalVisibleChars)
                {
                    i += 1;
                    Invoke("EndCheck", timeBtwnWords);
                    break;
                }

                counter += 1;
                yield return new WaitForSeconds(timeBtwnChars);
            }
        }
    }
}