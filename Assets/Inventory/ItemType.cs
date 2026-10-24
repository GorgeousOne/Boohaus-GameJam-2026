using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ItemType", menuName = "Items/Item Type")]
public class ItemType : ScriptableObject
{
    public BodyPart part;
    public Sprite icon;
    public Sprite fullImg;
    public List<CostumeTag> tags;
}
