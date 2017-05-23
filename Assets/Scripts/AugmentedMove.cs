using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EHand
{
    Right,
    Left
}

public class AugmentedMove : MonoBehaviour {

    //Amount of extra movement to add per tick, will add up very quickly
    public float AugmentIncrement = 0.25f;
    public bool Augment = false;

    public Transform AugmentTarget; 

    private Vector3 PrevPosition;
    private Quaternion PrevRot;
    private bool BaseSet = false;


	// Use this for initialization
	void Start () {

        PlayerPrefs.SetFloat("AugmentSlider", AugmentIncrement);
        transform.position = AugmentTarget.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (Augment)
        {

            PlayerPrefs.GetFloat("AugmentSlider");

            if (BaseSet)
            {
                Vector3 Diff = AugmentTarget.transform.position - PrevPosition;

                if (Diff.magnitude != 0)
                {

                    Vector3 AugmentedDiff = Diff + Diff * AugmentIncrement;
                    transform.position = transform.position + AugmentedDiff;

                    //Rotation Augment PROTOTYPE
                    float xRot = PrevRot.x - AugmentTarget.transform.rotation.x;
                    xRot = xRot + xRot * AugmentIncrement;
                    float yRot = PrevRot.y - AugmentTarget.transform.rotation.y;
                    yRot = yRot + yRot * AugmentIncrement;
                    float zRot = PrevRot.z - AugmentTarget.transform.rotation.z;
                    zRot = zRot + zRot * AugmentIncrement;

                    transform.rotation = new Quaternion(xRot,yRot,zRot, AugmentTarget.transform.rotation.w);
                }
            }

        }
        CaptureBase(AugmentTarget.transform);
    }

    void CaptureBase(Transform ObjectBase)
    {
        BaseSet = true;
        PrevPosition = ObjectBase.transform.position;
        PrevRot = ObjectBase.transform.rotation;
    }
}
