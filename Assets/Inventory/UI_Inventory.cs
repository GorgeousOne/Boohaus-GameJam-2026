using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{

    //IDK previously create item slots
    //rn maybe wait to see if this script can manage between dress item spawners & dress preview slots?


    // [SerializeField] GameObject slotPrefab;
    // private Transform slotContainer;
    // private List<UI_ItemSlot> slots = new();

    public void Awake()
    {
        // slotContainer = transform.Find("Slot Container");

        // //create example 2x2 slots
        // for (int y = 0; y < 2; ++y)
        // {
        //     for (int x = 0; x < 2; ++x)
        //     {
        //         GameObject slotObj = Instantiate(slotPrefab, slotContainer);
        //         slots.Add(slotObj.GetComponent<UI_ItemSlot>());

        //         RectTransform slotRect = slotObj.GetComponent<RectTransform>();

        //         slotRect.anchoredPosition = new Vector2(
        //             (x+0.5f) * slotRect.rect.width,
        //             -(y+0.5f) * slotRect.rect.height);
        //     }
        // }
    }
}
