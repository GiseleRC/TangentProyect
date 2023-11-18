using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Avatar Stats", menuName = "ScriptableObjects/GameCore/AvatarStats")]
public class AvatarStats : ScriptableObject
{
    [SerializeField] private string _price;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _avatarSprite;

    public string Price { get => _price; }

    public string Description { get => _description; }

    public Sprite AvatarSprite { get => _avatarSprite; }
}
