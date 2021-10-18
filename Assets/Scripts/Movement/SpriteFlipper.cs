using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    public bool    lookingRight = false;
    
    public void FlipSprite()
    {
        if (lookingRight)
            FlipLeft();
        else
            FlipRight();
    }

    public void FlipRight()
    {
        if (lookingRight)
            return;
        lookingRight = true;
        transform.Rotate(0, 180, 0);
    }

    public void FlipLeft()
    {
        if (!lookingRight)
            return;
        lookingRight = false;
        transform.Rotate(0, 180, 0);
    }
}