using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_DragDrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;

    public UnityEvent OnDropEvent;

    private bool checkIfEquippedNextFrame;

    [SerializeField] public ItemType itemType;

    bool isEquipped;
    Image sprite;

    public void SetEquipped(bool value) {
        isEquipped = value;
        sprite.color = value ? new Color(0.51f, 0.20f, 0.92f) : Color.white;
    }


    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        sprite = GetComponent<Image>();
    }

    public void setItem(ItemType item)
    {
        itemType = item;
        sprite.sprite = itemType.fullImg;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }

    //move item by mouse move drag movement
    public void OnDrag(PointerEventData eventData)
    {
        if (isEquipped)
        {
            return;
        }

        Vector2 delta = eventData.delta / canvas.scaleFactor;
        rectTransform.anchoredPosition += delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        checkIfEquippedNextFrame = true;
    }

    void Update()
    {
        if (checkIfEquippedNextFrame)
        {
            OnDropEvent.Invoke();
            checkIfEquippedNextFrame = false;
        }
    }
}
