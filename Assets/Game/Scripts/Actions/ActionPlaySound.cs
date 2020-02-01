using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPlaySound : AbstractAction
{

    public SoundFX soundFX;

    public override void PlayAction()
    {
        Sound.the.PlaySound(soundFX);
    }

}
