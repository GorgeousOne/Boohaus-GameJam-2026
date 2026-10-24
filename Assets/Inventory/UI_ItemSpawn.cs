using System;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_ItemSpawn : MonoBehaviour, IPointerDownHandler, IEndDragHandler
{

    [SerializeField] GameObject itemPrefab;
    public ItemType type;
    public UI_DragDrop currentItem;



    //change the item of the spawner
    public void SetItemType(ItemType type)
    {
        if (currentItem != null)
        {
            Debug.LogError("dont instantiate item twice");
        }
        this.type = type;
        GameObject item = Instantiate(itemPrefab, transform.parent);
        item.GetComponent<UI_DragDrop>().setItem(type);

        RectTransform itemRect = item.GetComponent<RectTransform>();
        RectTransform ownRect = GetComponent<RectTransform>();
        itemRect.position = ownRect.position;


        currentItem = itemRect.GetComponent<UI_DragDrop>();
        currentItem.OnDropEvent.AddListener(OnItemDrop);
    }

    public void hide()
    {
        if (currentItem)
        {
            currentItem.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }

    public void unhide()
    {
        if (currentItem)
        {
            currentItem.gameObject.SetActive(true);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    void OnItemDrop()
    {
        // if armorslots contains item.type => gray out item

        RectTransform itemRect = currentItem.GetComponent<RectTransform>();
        itemRect.position =  GetComponent<RectTransform>().position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // TODO find out if you can delete/"return" an item that was spawned here an not dropped in a slot
    }

    // // snap anything dropped on this slot
    // public void OnDrop(PointerEventData eventData)
    // {
    //     if (eventData.pointerDrag != null)
    //     {
    //         RectTransform itemRect = eventData.pointerDrag.GetComponent<RectTransform>();
    //         itemRect.position =  GetComponent<RectTransform>().position;
    //     }
    // }


}