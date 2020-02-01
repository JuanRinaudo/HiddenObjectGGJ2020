using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public KeyItem item;

    private RectTransform rectTransform;
    private Vector3 initialPosition;
    private Image image;

    public bool dragging;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        initialPosition = rectTransform.position;
        image = GetComponent<Image>();
    }

    public void SetItem(KeyItem keyItem)
    {
        item = keyItem;

        if (item != null)
        {
            image.sprite = item.sprite;
        }
        else
        {
            image.sprite = null;
        }
    }

    private void Update()
    {
        if(dragging)
        {
            rectTransform.position = Input.mousePosition;
        }
    }

    public void OnPointerDown (PointerEventData eventData)
    {
        dragging = true;
    }

    public void OnPointerUp (PointerEventData eventData)
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPosition, Vector2.zero, 0f);
        if (hit.transform)
        {
            InteractionDropKeyItem interaction = hit.transform.GetComponent<InteractionDropKeyItem>();
            if(interaction.targetItem == item)
            {
                interaction.DoInteractions();
                SetItem(null);
            }
        }

        dragging = false;
        rectTransform.position = initialPosition;
    }

}
