using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _itemName;
    [SerializeField] TextMeshProUGUI _itemRarity;
    [SerializeField] Image _itemImage;
    [SerializeField] Image _goldImage;
    [SerializeField] TextMeshProUGUI _tradeGold;

    public void SetItem(Item itemInfo)
    {
        _itemName.text = itemInfo.itemName;
        _itemRarity.text = itemInfo.rarity.ToString();
        _itemImage.sprite = itemInfo.itemImage;
        _goldImage.sprite = _goldImage.sprite;
        _tradeGold.text = itemInfo.itemTradeGold;
    }
}
