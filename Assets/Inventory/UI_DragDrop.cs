using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_DragDrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public UnityEvent OnDropEvent;
    Canvas canvas;

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
        //canvas in world space fucked the scale factor. hard coding it
        // Vector2 delta = eventData.delta * 1.9f; // / canvas.scaleFactor;
        // rectTransform.anchoredPosition += delta;

        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, Camera.main, out pos);
        var calcPos = canvas.transform.TransformPoint(pos);
        transform.position = calcPos;
        // rectTransform.anchoredPosition = calcPos;
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
            // Camera cam = GameObject.Find("Main Camera").GetComponent<Camera>();
            // Vector3 viewPos = transform.position; //cam.ScreenToWorldPoint(transform.position);
            // viewPos.z = 0;

            OnDropEvent.Invoke();
            checkIfEquippedNextFrame = false;
        }
    }
}
