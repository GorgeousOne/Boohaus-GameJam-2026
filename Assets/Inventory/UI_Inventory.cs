using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{

    [SerializeField] int slotsPerRow = 5;
    [SerializeField] int slotSize = 200;


    [SerializeField] GameObject slotPrefab;
    private Transform slotContainer;
    private Transform tabContainer;

    [SerializeField] List<ItemList> itemLists;

    Dictionary<BodyPart, List<UI_ItemSpawn>> slotLists = new();
    List<UI_ItemSpawn> currentSlots = new();

    void Awake()
    {
        slotContainer = transform.Find("Slot Container");
        tabContainer = transform.Find("Tab Bar");

        foreach (Transform tabTransform in tabContainer.transform)
        {
            ItemList items = tabTransform.GetComponent<ItemList>();
            createTabLayout(items);
        }

        foreach (Transform tabTransform in tabContainer.transform)
        {
            ItemList items = tabTransform.GetComponent<ItemList>();
            spawnItems(items);
        }
        ShowTab(BodyPart.HAT);
    }

    // //idk spawn items on top of all spawners, for ordering idl
    private void spawnItems(ItemList items)
    {
        List<UI_ItemSpawn> slots = slotLists[items.bodyPart];
        int i = 0;

        foreach (ItemType item in items.itemList)
        {
            slots[i].SetItemType(item);
            slots[i].hide();

            ++i;
        }
    }

    private void createTabLayout(ItemList items)
    {
        List<UI_ItemSpawn> slots = new();
        slotLists.Add(items.bodyPart, slots);
        int i = 0;

        foreach (ItemType item in items.itemList) {
            // TODO add spacing?
            float x = i % slotsPerRow;
            float y = -i / slotsPerRow;

            GameObject slotObj = Instantiate(slotPrefab, slotContainer);
            UI_ItemSpawn slot = slotObj.GetComponent<UI_ItemSpawn>();

            RectTransform transform = slot.GetComponent<RectTransform>();
            transform.anchoredPosition = new Vector2((x+0.5f) * slotSize, (y-0.5f) * slotSize);
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
        currentSlots = slotLists[bodyPart];
        foreach(UI_ItemSpawn slot in currentSlots)
        {
            slot.gameObject.SetActive(true);
            slot.unhide();
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
