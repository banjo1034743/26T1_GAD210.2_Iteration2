using UnityEngine;

namespace GAD210.P2.Iteration1.Environment
{
    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField] protected TextBoxDisplayer _textBoxDisplayer;

        protected bool CheckIfSelector(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Selector") == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Define whatever functionality we want in inheriting classes
        protected abstract void OnTriggerEnter2D(Collider2D other);
    }
}