using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public DropHandler[] equipmentSlots;

    private void OnValidate()
    {
        equipmentSlots = GetComponentsInChildren<DropHandler>();
    }

    public Transform GetClosestEquipmentSlot()
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (Vector2.Distance(equipmentSlots[i].transform.position, Input.mousePosition) < 35)
            {
                return equipmentSlots[i].transform;
            }
        }
        return null;
    }
}
