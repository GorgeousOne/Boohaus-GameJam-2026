using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{

    [SerializeField] int slotsPerRow = 5;
    [SerializeField] int slotSize = 200;

    [SerializeField] GameObject slotPrefab;
    [SerializeField] List<ItemList> itemLists;


    private Transform slotContainer;
    private Transform tabContainer;

    private Transform costumeView;
    Dictionary<BodyPart, Image> costumeSprites = new();
    private UI_ItemSlot equipper;
    Dictionary<BodyPart, ItemType> equippedItems = new();


    Dictionary<BodyPart, List<UI_ItemSpawn>> slotLists = new();
    List<UI_ItemSpawn> currentSlots = new();


    void Awake()
    {
        slotContainer = GameObject.Find("Slot Container").transform;
        tabContainer = GameObject.Find("Tab Bar").transform;
        costumeView = GameObject.Find("Costume View").transform;
        equipper = GameObject.Find("Equip Slot").GetComponent<UI_ItemSlot>();

        equipper.OnItemEquip.AddListener(OnItemEquip);
        costumeSprites.Add(BodyPart.PANTS, costumeView.Find("Pants").GetComponent<Image>());
        costumeSprites.Add(BodyPart.SHIRT, costumeView.Find("Shirt").GetComponent<Image>());
        costumeSprites.Add(BodyPart.FACE, costumeView.Find("Face").GetComponent<Image>());
        costumeSprites.Add(BodyPart.HAT, costumeView.Find("Hat").GetComponent<Image>());

        clearEquipped();

        //create slots & items
        foreach (Transform tabTransform in tabContainer.transform)
        {
            ItemList items = tabTransform.GetComponent<ItemList>();
            items.OnClick.AddListener(onSwitchView);
            createTabLayout(items);
        }

        foreach (Transform tabTransform in tabContainer.transform)
        {
            ItemList items = tabTransform.GetComponent<ItemList>();
            spawnItems(items);
        }
        // ShowTab(BodyPart.HAT);
    }

    void onSwitchView(BodyPart bodyPart)
    {
        ShowTab(bodyPart);
    }

    void clearEquipped()
    {
        foreach (Image img in costumeSprites.Values)
        {
            img.sprite = null;
            img.color = new Color(0, 0, 0, 0);
        }
    }

    // //idk spawn items on top of all spawners, for ordering idl
    private void spawnItems(ItemList items)
    {
        List<UI_ItemSpawn> slots = slotLists[items.bodyPart];
        int i = 0;

        foreach (ItemType item in items.itemList)
        {
            if (!item)
            {
                continue;
            }
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
            if (!item)
            {
                continue;
            }
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
            slot.hide();
        }
        currentSlots = slotLists[bodyPart];
        foreach(UI_ItemSpawn slot in currentSlots)
        {
            slot.gameObject.SetActive(true);
            slot.unhide();
        }
    }


    UI_ItemSpawn getSlotByItem(ItemType item)
    {
        foreach(UI_ItemSpawn child in slotLists[item.bodyPart])
        {
            if (child.type == item)
            {
                return child;
            }
        }
        return null;
    }

    public void OnItemEquip(ItemType item)
    {
        ItemType oldItem = equippedItems.GetValueOrDefault(item.bodyPart, null);

        // if (oldItem) {
        //     UI_ItemSpawn slot = getSlotByItem(oldItem);
        //     slot.currentItem.SetEquipped(false);
        // }

        // getSlotByItem(item).currentItem.SetEquipped(true);
        costumeSprites[item.bodyPart].sprite = item.fullImg;
        costumeSprites[item.bodyPart].color = Color.white;
    }
}
