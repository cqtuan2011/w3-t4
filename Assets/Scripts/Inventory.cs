using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public DropHandler[] slots;

    private void OnValidate()
    {
        if (slots == null)
        {
            slots = GetComponentsInChildren<DropHandler>();
        }
    }

    public Transform GetClosestSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (Vector2.Distance(slots[i].transform.position,Input.mousePosition) < 35)
            {
                return slots[i].transform;
            } 
        }
        return null;
    } 
}
