using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Avatar Stats", menuName = "ScriptableObjects/GameCore/AvatarStats")]
public class AvatarStats : ScriptableObject
{
    [SerializeField] private int _price;
    [SerializeField] private int _avatarIndex;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _avatarSprite;

    public int Price { get => _price; }
    public int AvatarIndex { get => _avatarIndex; }
    public string Description { get => _description; }
    public Sprite AvatarSprite { get => _avatarSprite; }
}
