using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundary : MonoBehaviour {

    private float minX, maxX, minY, maxY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Clamps x pos within screen
        Vector2 screendims = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width , Screen.height));    
        Vector2 shapedims = GetComponent<SpriteRenderer>().sprite.bounds.extents;

        minX = -screendims.x + shapedims.x;
        maxX = screendims.x - shapedims.x;
        minY = -screendims.y + shapedims.y;
        maxY = screendims.y - shapedims.y;
        Vector3 curpos = transform.position;
        float clampedx = Mathf.Clamp(curpos.x , minX , maxX);
        float clampedy = Mathf.Clamp(curpos.y , minY , maxY);
        curpos.x = clampedx;
        curpos.y = clampedy;
        transform.position = curpos;
	}
}
