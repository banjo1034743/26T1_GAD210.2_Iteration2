using GAD210.P2.Iteration1.Microgame;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "CarCrashPoliceTile", menuName = "Tiles/Police Car Crash Tile")]
public class CarCrashPoliceTile : Tile
{
    //[SerializeField] private Sprite _defaultSprite;

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);

        if (CarCrashPoliceManager.instance != null)
        {
            if (CarCrashPoliceManager.instance.IsOpened == true)
            {
                tileData.sprite = CarCrashPoliceManager.instance.CarCrashSpriteOpened;
            }
            else
            {
                tileData.sprite = CarCrashPoliceManager.instance.CarCrashSpriteClosed;
            }
        }

        //tileData.sprite = _defaultSprite;
    }      
}
