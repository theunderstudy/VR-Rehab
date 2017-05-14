using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AugmentedMove : MonoBehaviour {

    //Amount of extra movement to add per tick, will add up very quickly
    public float AugmentIncrement = 0.01f;
    public Transform AugmentTarget; 


    private Vector3 BasePosition;
    private bool BaseSet = false;


	// Use this for initialization
	void Start () {
        transform.position = AugmentTarget.position;
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 Diff = transform.position - BasePosition;

        if(Diff.magnitude != 0)
        {

            Vector3 AugmentedDiff = Diff + Diff * AugmentIncrement;
            transform.position = transform.position + AugmentedDiff;
        }
	}

    void CaptureBase()
    {
        BaseSet = true;
        BasePosition = transform.position;
    }
}
