using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{

    [SerializeField] int slotsPerRow = 5;
    [SerializeField] int slotSize = 200;


    [SerializeField] UI_ItemSpawn slotPrefab;
    private Transform slotContainer;
    private Transform tabContainer;

    [SerializeField] List<ItemList> itemLists;

    Dictionary<BodyPart, List<UI_ItemSpawn>> slotLists = new();
    List<UI_ItemSpawn> currentSlots;

    void Awake()
    {
        slotContainer = transform.Find("Slot Container");
        tabContainer = transform.Find("Tab Bar");

        foreach (Transform tabTransform in tabContainer.transform)
        {
            ItemList items = tabTransform.GetComponent<ItemList>();
            createTabLayout(items);
        }
        ShowTab(BodyPart.HAT);
    }

    private void createTabLayout(ItemList items)
    {
        List<UI_ItemSpawn> slots = new();
        slotLists.Add(items.bodyPart, slots);
        int i = 0;

        foreach (ItemType item in items.itemList) {
            // TODO add spacing?
            float x = i % slotsPerRow * slotSize;
            float y = i / slotsPerRow * slotSize;

            UI_ItemSpawn slot = Instantiate(slotPrefab, Vector3.zero, Quaternion.identity);
            slot.transform.parent = slotContainer;
            slot.SetItemType(item);
            RectTransform transform = slot.GetComponent<RectTransform>();
            transform.anchoredPosition = new Vector2((x+0.5f) * slotSize, (x+0.5f) * slotSize);
            slot.gameObject.SetActive(false);
            slots.Add(slot);
            ++i;
        }
    }

    public void ShowTab(BodyPart bodyPart)
    {
        foreach(UI_ItemSpawn slot in currentSlots)
        {
            slot.gameObject.SetActive(false);
        }
        foreach(UI_ItemSpawn slot in currentSlots)
        {
            slot.gameObject.SetActive(true);
        }
    }

    // public void ShowItems()
    // {
    //     slotContainer = transform.Find("Slot Container");

    //     // //create example 2x2 slots
    //     for (int y = 0; y < 2; ++y)
    //     {
    //         for (int x = 0; x < 2; ++x)
    //         {
    //             GameObject slotObj = Instantiate(slotPrefab, slotContainer);
    //             slots.Add(slotObj.GetComponent<UI_ItemSlot>());

    //             RectTransform slotRect = slotObj.GetComponent<RectTransform>();

    //             slotRect.anchoredPosition = new Vector2(
    //                 (x+0.5f) * slotRect.rect.width,
    //                 -(y+0.5f) * slotRect.rect.height);
    //         }
    //     }
    // }
}
