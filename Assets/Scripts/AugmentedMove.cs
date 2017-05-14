using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AugmentedMove : MonoBehaviour {

    //Amount of extra movement to add per tick, will add up very quickly
    public float AugmentIncrement = 0.01f;
    public Transform AugmentTarget; 


    private Vector3 PrevPosition;
    private bool BaseSet = false;


	// Use this for initialization
	void Start () {
        transform.position = AugmentTarget.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (BaseSet)
        {
            Vector3 Diff = AugmentTarget.transform.position - PrevPosition;

            if (Diff.magnitude != 0)
            {

                Vector3 AugmentedDiff = Diff + Diff * AugmentIncrement;
                transform.position = transform.position + AugmentedDiff;
            }
        }

        CaptureBase(AugmentTarget.transform);
    }

    void CaptureBase(Transform ObjectBase)
    {
        BaseSet = true;
        PrevPosition = ObjectBase.transform.position;
    }
}
