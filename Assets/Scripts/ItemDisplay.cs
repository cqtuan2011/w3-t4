using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public Item item;
    public Image image;
    public Text quantity;

    // Start is called before the first frame update
    private void OnValidate()
    {
        if (item == null)
        {
            image.enabled = false;
            quantity.text = null;
        }
        else
        {
            image.sprite = item.Icon;
            image.enabled = true;
            quantity.text = item.Quantity.ToString();
        }
    }
}
