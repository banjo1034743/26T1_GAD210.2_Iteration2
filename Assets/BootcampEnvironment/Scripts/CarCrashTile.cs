using GAD210.P2.Iteration1.Microgame;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "CarCrashTile", menuName = "Tiles/Car Crash Tile")]
public class CarCrashTile : Tile
{
    //[SerializeField] private Sprite _defaultSprite;

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);

        if (CarCrashManager.instance != null)
        {
            if (CarCrashManager.instance.IsOpened == true)
            {
                tileData.sprite = CarCrashManager.instance.CarCrashSpriteOpened;
            }
            else
            {
                tileData.sprite = CarCrashManager.instance.CarCrashSpriteClosed;
            }
        }

        //tileData.sprite = _defaultSprite;
    }      
}
