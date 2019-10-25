using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glowing : MonoBehaviour {

    public float glowfactor;
    public bool on;

    public bool lerpglow;
    public float minglow, minv;
    public float t;
    public float tDelta;

    public void SetPlaced()
    {
        lerpglow = true;
        Color curColor = GetComponent<SpriteRenderer>().color;
        float h, s, v;
        Color.RGBToHSV(curColor , out h , out s , out v);

        minglow = curColor.a;
        minv = s;
    }

    public void UnGlow()
    {   
        if(on)
        {
            Color curColor = GetComponent<SpriteRenderer>().color;
            curColor.a /= glowfactor;
            GetComponent<SpriteRenderer>().color = curColor;
            on = false;
        }
    }

    public void Glow()
    {
        if(!on)
        {
            Color curColor = GetComponent<SpriteRenderer>().color;
            curColor.a *= glowfactor;
            GetComponent<SpriteRenderer>().color = curColor;
            on = true;
        }
    }
}
