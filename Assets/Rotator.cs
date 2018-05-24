using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Camera.main.transform.position;	
	}

    public Vector3 LookAt(Transform trans) {
        this.transform.LookAt(trans);

        Vector3 angle = new Vector3(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z);
        return angle;
    }
}
