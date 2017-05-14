using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour {

    public bool MirrorToHand = false;
    public Transform MirrorFromHand;
    public Transform Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(MirrorToHand == true)
        {
            this.enabled = true; 
            transform.position = new Vector3(MirrorFromHand.position.x - Player.position.x, MirrorFromHand.position.y, MirrorFromHand.position.z);

        }
	}
}
