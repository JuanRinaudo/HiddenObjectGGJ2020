using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionOnClick : AbstractInteraction
{

    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPosition, Vector2.zero, 0f);
        if (hit.transform == transform)
        {
            DoInteractions();
        }
        else if(hit.transform != null)
        {
            Debug.Log(hit.transform.name);
        }
    }

}
