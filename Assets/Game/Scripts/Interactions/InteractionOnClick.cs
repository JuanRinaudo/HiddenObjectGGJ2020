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
        DoInteractions();
    }

}
