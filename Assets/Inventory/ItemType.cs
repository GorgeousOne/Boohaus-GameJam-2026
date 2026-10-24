using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemType", menuName = "Items/Item Type")]
public class ItemType : ScriptableObject
{
    public BodyPart part;
    public Sprite sprite;
    public List<CostumeTag> tags;
}
