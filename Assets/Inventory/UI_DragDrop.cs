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


    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        // display item
        Image sprite = GetComponent<Image>();
        sprite.sprite = itemType.icon;
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
