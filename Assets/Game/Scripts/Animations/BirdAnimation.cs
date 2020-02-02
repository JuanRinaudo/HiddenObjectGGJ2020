using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimation : MonoBehaviour
{

    public GameObject freebird;
    public Transform birdEnd;
    private Animator birdAnimator;

    void OnEnable()
    {
        birdAnimator = freebird.GetComponent<Animator>();
        birdAnimator.SetBool("Moving", true);

        LeanTween.move(freebird, birdEnd, 2f).setOnComplete(BirdStopped);
    }

    void BirdStopped()
    {
        birdAnimator.SetBool("Moving", false);
    }
    
    void Update()
    {
        
    }

}
