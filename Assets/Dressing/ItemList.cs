using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    [SerializeField] public BodyPart bodyPart;
    [SerializeField] public List<ItemType> itemList = new();
}
