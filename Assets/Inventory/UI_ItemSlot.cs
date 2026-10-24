using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UI_ItemSlot : MonoBehaviour, IDropHandler
{

    public UnityEvent<ItemType> OnItemEquip;

    // snap anything dropped on this slot
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            // RectTransform itemRect = eventData.pointerDrag.GetComponent<RectTransform>();
            // itemRect.position =  GetComponent<RectTransform>().position;
            UI_DragDrop item = eventData.pointerDrag.GetComponent<UI_DragDrop>();
            OnItemEquip.Invoke(item.itemType);
        }
    }
}