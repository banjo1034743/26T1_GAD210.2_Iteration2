using UnityEngine;

namespace GAD210.P2.Iteration1.Player
{
    /// <summary>
    /// This is the class that handles changing the sprites of our player
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerSpriteManager : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [Tooltip("These are the sprites that we choose from to display depending on what we're doing.")]
        [SerializeField] protected Sprite[] playerSprites;

        [Header("Components")]

        [Tooltip("Our reference to the SpriteRenderer. We use this for chaging the our sprite based on what direction we're moving.")]
        [SerializeField] protected SpriteRenderer spriteRenderer;

        #endregion

        #region Methods

        public void ChangePlayerSprite(string animationClipPlayed)
        {
            switch (animationClipPlayed)
            {
                case "Down":
                    spriteRenderer.sprite = playerSprites[0];
                    break;
                case "Up":
                    spriteRenderer.sprite = playerSprites[1];
                    break;
                case "Right":
                    spriteRenderer.sprite = playerSprites[2];
                    break;
                case "Left":
                    spriteRenderer.sprite = playerSprites[3];
                    break;
            }
        }

        public void SetPlayerSprite(Sprite spriteToChangeTo)
        {
            spriteRenderer.sprite = spriteToChangeTo;
        }

        #endregion

        #region Unity Methods

        private void Awake()
        {
            SetPlayerSprite(playerSprites[0]);
        }

        #endregion
    }
}