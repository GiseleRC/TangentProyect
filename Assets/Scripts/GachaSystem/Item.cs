using UnityEngine;

[CreateAssetMenu(fileName = "My new Item", menuName = "ScriptableObjects/GameCore/ItemStats")]
public class Item : ScriptableObject
{
    public string itemName;
    public string itemCost;
    public Sprite itemImage;
    public ItemsRarity rarity;
}
