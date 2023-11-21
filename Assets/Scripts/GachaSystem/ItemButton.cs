using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _itemName;
    [SerializeField] TextMeshProUGUI _itemCost;
    [SerializeField] TextMeshProUGUI _itemRarity;
    [SerializeField] Image _itemImage;

    public void SetItem(Item itemInfo)
    {
        _itemName.text = itemInfo.itemName;
        _itemCost.text = "Orbs " + itemInfo.itemCost;
        _itemRarity.text = itemInfo.rarity.ToString();
        _itemImage.sprite = itemInfo.itemImage;
    }
}
