using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ddol : MonoBehaviour {


    public static ddol instance;

    void ApplySingleton()
    {
        if(instance == null)
            instance = this;

        else if(instance != this)
            Destroy(gameObject);
    }

    private void Awake()
    {
        ApplySingleton();
    }

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
	}

    public void Play()
    {
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
