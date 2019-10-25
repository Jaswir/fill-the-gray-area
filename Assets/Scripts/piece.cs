using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class piece : MonoBehaviour
{
    public string piecename;
    public bool placed = false;
    public bool deactivated = false;
    public Vector3 startpos;

    private void Start()
    {
        startpos = transform.position;
    }

    private void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
    }

    void OnMouseDrag()
    {
        if(deactivated) return;
        if(placed) return;

        gamemanager.instance.holdingpiece = true;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 5;
        transform.position = mousePos;


        //if not glowing glow
        if(!GetComponent<glowing>().on)
            GetComponent<glowing>().Glow();
    }

    private void OnMouseUp()
    {
        if(deactivated)
        {
            placed = false;
            deactivated = false;
        }

        if(placed) return;
        //unglow
        if(GetComponent<glowing>().on)
            GetComponent<glowing>().UnGlow();

        gamemanager.instance.holdingpiece = false;
    }


    public void SetPlaced()
    {
        placed = true;
    }

    public void Reset()
    {
        deactivated = true;
        transform.position = startpos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "boundary") deactivated = true;
    }

}