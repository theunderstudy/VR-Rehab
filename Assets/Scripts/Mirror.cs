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


        this.enabled = true;
        transform.position = new Vector3(MirrorFromHand.position.x, MirrorFromHand.position.y, MirrorFromHand.position.z - Player.position.z);
        transform.rotation = new Quaternion(MirrorFromHand.rotation.x, MirrorFromHand.rotation.y, MirrorFromHand.rotation.z, MirrorFromHand.rotation.w);
    }
}
