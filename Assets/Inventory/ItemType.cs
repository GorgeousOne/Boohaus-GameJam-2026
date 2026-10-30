using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ItemType", menuName = "Items/Item Type")]
public class ItemType : ScriptableObject
{
    [FormerlySerializedAs("part")]
    public BodyPart bodyPart;
    public Sprite fullImg;
    public Sprite menuImg;
    public List<CostumeTag> tags;
}
