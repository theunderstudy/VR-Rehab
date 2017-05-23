using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripHand : MonoBehaviour {

    public Rigidbody attachPoint;
    public Transform Hand;
    SteamVR_TrackedObject trackedObj;
    FixedJoint joint;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {

        var device = SteamVR_Controller.Input((int)trackedObj.index);
        if (joint == null && device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            RaycastHit hit;
            Physics.SphereCast(Hand.position, 1, new Vector3(0, 0, 0), out hit);

            if (hit.rigidbody && hit.rigidbody.tag == "Interactable")
            {
                GameObject GrabObject = hit.rigidbody.GetComponent<GameObject>();
                GrabObject.transform.position = attachPoint.transform.position;

                joint = GrabObject.AddComponent<FixedJoint>();
                joint.connectedBody = attachPoint;
            }
        }
        else if (joint != null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            //Drop
            var GrabObject = joint.gameObject;
            var RigidBody = GrabObject.GetComponent<Rigidbody>();

            Object.DestroyImmediate(joint);
            joint = null;
        }
    }
}
