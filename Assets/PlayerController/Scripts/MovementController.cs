using UnityEngine;
using UnityEngine.Tilemaps;

namespace GAD210.P2.Iteration1.Player
{
    /// <summary>
    /// This class handles the controlling of the player in the game, including movement and other interactions
    /// </summary>
    [RequireComponent(typeof(PlayerAnimationManager))]
    [RequireComponent(typeof(InputManager))]
    public class MovementController : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [Tooltip("Our movement speed. This determines how fast the player will travel in the world between tiles.")]
        [SerializeField] protected float movementSpeed;

        [Tooltip("This is the position we spawn the player at. Whenever the game starts, our player will start at the position specified.")]
        [SerializeField] protected Vector2 spawnPos;

        [Tooltip("This is where the movePoint of our player spawns. We want to make sure that we have it with us when we start so the player can move accuratley")]
        [SerializeField] protected Vector2 movePointSpawnPos;

        // This is a bool we use to dictate if whether the player can move or not. It is used when calling ToggleRestrictPlayer()
        private bool isAbleToMove = true;

        [Header("Components")]

        [Tooltip("This is the move point that guides the player to the next tile. It is what we actually move when moving to different tiles, before having the player move toward the tile the move point went to.")]
        [SerializeField] protected Transform movePoint;

        [Tooltip("This is the tilemap we use to move on the ground. We reference it for checking if the tile we're about to move on is one belonging to this")]
        [SerializeField] protected Tilemap groundTilemap;

        [Tooltip("This is the tilemap we have our collisions on. We reference it so we know not to move on tiles in this tilemap.")]
        [SerializeField] protected Tilemap collisionTilemap;

        [Header("Scripts")]

        [Tooltip("This is the script we use to access the method for enabling animation triggers when needed.")]
        [SerializeField] protected PlayerAnimationManager playerAnimationManager;

        //[Tooltip("This is the script we use to acces the method for opening and closing the exit window.")]
        //[SerializeField] protected ExitWindow exitWindow;

        [Tooltip("This is the script we use to access the input values of the player.")]
        [SerializeField] protected InputManager inputManager;

        private Controls controls;

        #endregion

        #region Methods

        public virtual void ToggleRestrictPlayer(bool valueToSetTo)
        {
            isAbleToMove = valueToSetTo;
        }

        public virtual void TeleportPlayer(Vector2 newPos)
        {
            ToggleRestrictPlayer(false);
            transform.position = newPos;
            ToggleRestrictPlayer(true);
        }

        public virtual void SetMovementSpeedValue(float valueToSetTo)
        {
            movementSpeed = valueToSetTo;
        }

        protected virtual void MovePlayer()
        {
            if (isAbleToMove)
            {
                //Debug.Log("isAbleToMove is: [" + isAbleToMove + "]");

                // We move to our new position, which is where the movepoint currently is
                transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movementSpeed * Time.deltaTime);

                // We check if we can move on top of the square in front of us, before checking to see if the player is giving input to move
                if (CanMove(inputManager.GetDirectionValue()))
                {
                    //Debug.Log("GetDirectionValue() has returned: [" + CanMove(inputManager.GetDirectionValue()) + "]");

                    if (Vector3.Distance(transform.position, movePoint.position) <= 0.1f)
                    {
                        if (Mathf.Abs(inputManager.GetDirectionValue().x) == 1f)
                        {
                            playerAnimationManager.SetAnimationTriggerWalkingHorizontal();

                            movePoint.position += new Vector3(inputManager.GetDirectionValue().x, 0f, 0f);

                            //if (shovelRotator.transform.gameObject.activeSelf)
                            //{
                            //    shovelRotator.RotateShovel(90 * inputManager.GetDirectionValue().x);
                            //}
                        }

                        if (Mathf.Abs(inputManager.GetDirectionValue().y) == 1f)
                        {
                            playerAnimationManager.SetAnimationTriggerWalkingVertical();

                            movePoint.position += new Vector3(0f, inputManager.GetDirectionValue().y, 0f);

                            //if (shovelRotator.transform.gameObject.activeSelf)
                            //{
                            //    if (inputManager.GetDirectionValue().y > 0f)
                            //    {
                            //        shovelRotator.RotateShovel(180 * inputManager.GetDirectionValue().y);
                            //    }
                            //    else
                            //    {
                            //        shovelRotator.RotateShovel(0);
                            //    }
                            //}
                        }
                    }
                }
            }
        }

        protected virtual void ResetPlayerPosition()
        {
            transform.position = spawnPos;
            movePoint.transform.position = movePointSpawnPos;
        }

        protected virtual bool CanMove(Vector2 direction)
        {
            Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)direction);

            if (ComponentNullCheck(groundTilemap))
            {
                if (!groundTilemap.HasTile(gridPosition))
                {
                    return false;
                }
            }
            if (ComponentNullCheck(collisionTilemap))
            {
                if (collisionTilemap.HasTile(gridPosition))
                {
                    return false;
                }
            }

            return true;
        }

        protected virtual bool ComponentNullCheck<T>(T componentToCheck)
        {
            if (componentToCheck.Equals(null))
            {
                Debug.LogError("This component has no reference to it. Please make sure there is one if needed.");
                return false;
            }
            else
            {
                return true;
            }
        }

        //protected virtual void OpenEscape()
        //{
        //    if (inputManager.GetEscapeBoolValue())
        //    {
        //        exitWindow.ToggleExitPrompt(true);
        //    }
        //}

        protected virtual void GetObjects()
        {
            playerAnimationManager = GetComponent<PlayerAnimationManager>();
            inputManager = GetComponent<InputManager>();

            if (GameObject.FindGameObjectWithTag("GroundGrid").GetComponent<Tilemap>() != null && groundTilemap == null)
            {
                groundTilemap = GameObject.FindGameObjectWithTag("GroundGrid").GetComponent<Tilemap>();
            }

            if (GameObject.FindGameObjectWithTag("CollisionsGrid").GetComponent<Tilemap>() != null && collisionTilemap == null)
            {
                collisionTilemap = GameObject.FindGameObjectWithTag("CollisionsGrid").GetComponent<Tilemap>();
            }

            movePoint.parent = null; //culprit
        }

        #endregion

        #region Unity Methods

        protected virtual void Awake()
        {
            controls = new Controls();
        }

        protected virtual void Start()
        {
            GetObjects();
            ResetPlayerPosition();
        }

        protected virtual void Update()
        {
            MovePlayer();
            //OpenEscape();
        }

        #endregion
    }
}