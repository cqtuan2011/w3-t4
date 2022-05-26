using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private CanvasGroup canvasGroup;
    private Inventory inventory;
    private Transform dragItemParent;
    private Transform temp;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        inventory = FindObjectOfType<Inventory>();
        temp = GameObject.FindGameObjectWithTag("TempSlot").transform;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        dragItemParent = eventData.pointerDrag.transform.parent;

        transform.SetParent(temp);

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;

        if (inventory.GetClosestSlot().childCount == 0) // drag & drop
        {
            eventData.pointerDrag.transform.SetParent(inventory.GetClosestSlot());
        }
        else // Swap item
        {
            eventData.pointerDrag.transform.SetParent(inventory.GetClosestSlot());
            inventory.GetClosestSlot().GetChild(0).transform.SetParent(dragItemParent);
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.slots[i].transform.childCount != 0)
                {
                    inventory.slots[i].transform.GetChild(0).localPosition = Vector3.zero;
                }
            }
        }
        eventData.pointerDrag.transform.localPosition = Vector3.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
    }

}
