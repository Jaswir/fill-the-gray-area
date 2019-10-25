using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grayarea : MonoBehaviour {

    public bool Filled;
    public GameObject fillshape;
    public AudioClip correct;
    public AudioClip incorrect;

    public string shapetype;

    public bool filled {
        get
        {
            return Filled;
        }
        set
        {
           Filled = value;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(filled) return;

        fillshape = collision.gameObject;

        //Detects whether placed piece matches the gray area type
        string colshapetype = fillshape.GetComponent<piece>().piecename;
        bool correcttype = shapetype == colshapetype;


        ///No -> place back at startposition
        if(!correcttype) {
            GetComponent<AudioSource>().clip = incorrect;
            GetComponent<AudioSource>().Play();
            fillshape.GetComponent<piece>().Reset();
            return;
        }

        ///Otherwise place
        GetComponent<AudioSource>().clip = correct;
        GetComponent<AudioSource>().Play();

        //places
        fillshape.transform.position = transform.position;
        fillshape.GetComponent<piece>().SetPlaced();
        fillshape.GetComponent<glowing>().SetPlaced();
        fillshape.GetComponent<scaling>().placed = true;
        fillshape.GetComponent<scaling>().hovering = false;

        //Destroys boxcolliders
        Destroy(collision.gameObject.GetComponent<Collider2D>());
        Destroy(GetComponent<Collider2D>());

       
        filled = true;
    }


    private void Update()
    {

        if(filled)
        {
            //fades area
            SpriteRenderer areasr = GetComponent<SpriteRenderer>();
            Color areaCol = areasr.color;
            areaCol.a -= gamemanager.instance.alphaDelta * Time.deltaTime;
            areasr.color = areaCol;

            //fades fillshape
            SpriteRenderer fillsr = fillshape.GetComponent<SpriteRenderer>();
            Color fillCol = fillsr.color;
            fillCol.a -= gamemanager.instance.alphaDelta * Time.deltaTime;
            fillsr.color = fillCol;

            //Scene switch upon fade out
            if(areaCol.a <= 0.0f)
            {
                //removes this ga from gamemanager
                gamemanager.instance.RemoveGrayArea(this);

                //Delete yourself
                Destroy(gameObject);
                Destroy(fillshape);
            }
        }
    }
}
