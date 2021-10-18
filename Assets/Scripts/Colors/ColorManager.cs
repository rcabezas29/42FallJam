using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public int  color = 0;
    public int currentColor = 0;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (color != currentColor)
        {
            currentColor = color;
            if (color == 2)
                sr.color = Color.blue;
            if (color == 1)
                sr.color = Color.yellow;
            if (color == 0)
                sr.color = Color.white;
        }
    }
}
