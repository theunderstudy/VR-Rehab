using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tkscript : MonoBehaviour {
    public static tkscript instance;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    // Use this for initialization
    void Start () {
        if (instance != null)
        {
            //destroy the entire game object
            //since we don't want to double up on ui
            Destroy(gameObject);
            return;
        }
        //set up our singleton instance
        instance = this;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
