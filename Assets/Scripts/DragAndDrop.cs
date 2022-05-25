using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private CanvasGroup canvasGroup;
    private DropHandler dropHandler;
    private Inventory inventory;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        dropHandler = FindObjectOfType<DropHandler>();
        inventory = FindObjectOfType<Inventory>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        eventData.pointerDrag.transform.SetParent(inventory.GetClosetSlot().transform);
        eventData.pointerDrag.transform.position = inventory.GetClosetSlot().transform.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
    }
}
