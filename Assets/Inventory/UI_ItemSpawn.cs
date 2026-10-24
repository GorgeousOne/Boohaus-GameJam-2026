using UnityEngine;
using UnityEngine.EventSystems;

public class UI_ItemSpawn : MonoBehaviour, IPointerDownHandler, IEndDragHandler
{

    ItemType type;
    UI_DragDrop currentItem;

    //change the item of the spawner
    public void SetItemType(ItemType type)
    {
        this.type = type;

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