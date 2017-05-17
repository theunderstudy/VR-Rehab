using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public EHand Hand = EHand.Right;

    private Transform MirrorFromHand;
    private Transform Player;

    // Use this for initialization
    void Start()
    {
        if (Hand == EHand.Right)
        {
            MirrorFromHand = GameObject.Find("Controller (left)").transform;
        }
        else
        {
            MirrorFromHand = GameObject.Find("Controller (right)").transform;
        }

        Player = GameObject.Find("Camera (eye)").transform;

    }

    // Update is called once per frame
    void Update()
    {

        float XMirrored = (Player.position.x - MirrorFromHand.position.x) * 2;

        transform.position = new Vector3(XMirrored, MirrorFromHand.position.y, MirrorFromHand.position.z);
        transform.rotation = new Quaternion(MirrorFromHand.rotation.x, MirrorFromHand.rotation.y, MirrorFromHand.rotation.z, MirrorFromHand.rotation.w);
    }
}
