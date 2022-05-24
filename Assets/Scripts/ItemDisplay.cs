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
    void Start()
    {
        image.sprite = item.Icon;
        quantity.text = item.Quantity.ToString();
    }
}
