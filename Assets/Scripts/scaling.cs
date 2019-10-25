using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaling : MonoBehaviour {

    public bool hovering;
    public bool big;
    public bool placed;

    public float xscalefactor;
    public float yscalefactor;
    public float minxScale;
    public float maxxScale;
    public float minyScale;
    public float maxyScale;

    public float t = 0;
    public float tDelta;
    

	// Use this for initialization
	void Start () {
        minxScale = transform.localScale.x;
        minyScale = transform.localScale.y;
        maxxScale = minxScale * xscalefactor;
        maxyScale = minyScale * yscalefactor;

    }

    private void OnMouseExit()
    {
 
        hovering = false;
    }

    private void OnMouseOver()
    {
        if(gamemanager.instance.holdingpiece) return;
        if(placed) return;
        hovering = true;
    }

    // Update is called once per frame
    void Update () {

        //Scale up
        if(hovering && !big)
        {
            Vector3 curscale = transform.localScale;
            float nextxscale = Mathf.Lerp(minxScale , maxxScale , t);
            float nextyscale = Mathf.Lerp(minyScale , maxyScale , t);
            curscale.x = nextxscale;
            curscale.y = nextyscale;
            transform.localScale = curscale;

            t += tDelta * Time.deltaTime;
            if(t >= 1)
            {
                big = true;
                t = 0;
            }
        }

        //Scale down
        if(!hovering && big)
        {
            Vector3 curscale = transform.localScale;
            float nextxscale = Mathf.Lerp(maxxScale , minxScale , t);
            float nextyscale = Mathf.Lerp(maxyScale , minyScale , t);
            curscale.x = nextxscale;
            curscale.y = nextyscale;
            transform.localScale = curscale;

            t += tDelta * Time.deltaTime;
            if(t >= 1)
            {
                big = false;
                t = 0;
            }
        }

    }
}
