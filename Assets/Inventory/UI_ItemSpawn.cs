using System;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_ItemSpawn : MonoBehaviour, IPointerDownHandler, IEndDragHandler
{

    [SerializeField] GameObject itemPrefab;
    ItemType type;
    UI_DragDrop currentItem;


    //change the item of the spawner
    public void SetItemType(ItemType type)
    {
        this.type = type;
        GameObject item = Instantiate(itemPrefab, transform.parent);
        Debug.Log(item);

        RectTransform itemRect = item.GetComponent<RectTransform>();
        RectTransform ownRect = GetComponent<RectTransform>();
        itemRect.position = ownRect.position;


        currentItem = itemRect.GetComponent<UI_DragDrop>();

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