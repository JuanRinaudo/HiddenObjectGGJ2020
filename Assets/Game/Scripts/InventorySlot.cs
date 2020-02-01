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
    private Sprite baseSprite;

    public bool interactuable = true;
    private bool dragging;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        initialPosition = rectTransform.position;
        image = GetComponent<Image>();
        image.color = new Color(0, 0, 0, 0);
        baseSprite = image.sprite;
    }

    public void SetItem(KeyItem keyItem)
    {
        item = keyItem;

        if (item != null)
        {
            image.sprite = item.sprite;
            image.color = new Color(1, 1, 1, 1);
        }
        else
        {
            image.sprite = baseSprite;
            image.color = new Color(0, 0, 0, 0);
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
        if(interactuable)
        {
            dragging = true;
        }
    }

    public void OnPointerUp (PointerEventData eventData)
    {
        if (interactuable)
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPosition, Vector2.zero, 0f);
            if (hit.transform)
            {
                InteractionDropKeyItem interaction = hit.transform.GetComponent<InteractionDropKeyItem>();
                if (interaction != null && interaction.targetItem == item)
                {
                    interaction.DoInteractions();
                    SetItem(null);
                }
            }

            dragging = false;
            rectTransform.position = initialPosition;
        }
    }

}
