using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemList : MonoBehaviour
{
    [SerializeField] public BodyPart bodyPart;
    [SerializeField] public List<ItemType> itemList = new();

    public UnityEvent<BodyPart> OnClick;

    public void Click()
    {
        OnClick.Invoke(bodyPart);
    }
}
