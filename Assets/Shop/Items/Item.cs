using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    [SerializeField] private string _itemName;
    public string ItemName { get { return _itemName; } }

    [SerializeField] private float _itemPrice;
    public float ItemPrice { get { return _itemPrice; } }

    [SerializeField] private Sprite _itemSprite;
    public Sprite ItemSprite { get { return _itemSprite; } }
}
