using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Avatar : MonoBehaviour
{
    [SerializeField] private TypeOfAvatar _typeOfAvatar;
    [SerializeField] private AvatarStats _stats;

    private int _price;
    private int _avatarIndex;
    private string _description;
    private Sprite _avatarSprite;

    public enum TypeOfAvatar
    {
        Default,
        Rogue,
        Warrior,
        Wizard
    }

    void Start()
    {
        _price = _stats.Price;
        _avatarIndex = _stats.AvatarIndex;
        _description = _stats.Description;
        gameObject.GetComponent<Image>().sprite = _stats.AvatarSprite;
    }
}
