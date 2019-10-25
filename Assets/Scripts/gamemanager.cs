using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour {

    public bool fade = false;
    public bool holdingpiece = false;
    public float alphaDelta = 0.03f;

    public List<grayarea> grayareas;

    public static gamemanager instance;

    void ApplySingleton()
    {
        if(instance == null)
            instance = this;

        else if(instance != this)
            Destroy(gameObject);
    }
    void FillGrayareaArrays()
    {
        GameObject[] gaObjects = GameObject.FindGameObjectsWithTag("grayarea");
        grayareas = new List<grayarea>();

        foreach(GameObject go in gaObjects)
        {
            grayareas.Add(go.GetComponent<grayarea>());
        }

    }

    private void Awake()
    {
        ApplySingleton();
        FillGrayareaArrays();

    }

    // Update is called once per frame
    void Update () {


        LevelNavigation();
    }


    public void RemoveGrayArea(grayarea ga)
    {
        grayareas.Remove(ga);

        //If no more grayareas go next level
        if(grayareas.Count == 0)
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
            ddol.instance.Play();
        }
    }

    void LevelNavigation()
    {
        //level up
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }

        //level down
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int prevSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
            SceneManager.LoadScene(prevSceneIndex);
        }
    }
   
}
