using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LookAt : MonoBehaviour {
    
	public Transform chopper;

	public float offSetZ;
	public float offSetY;
	public float speed = 1;
	
    void FixedUpdate ()
	{
			transform.LookAt(new Vector3(chopper.position.x, chopper.position.y + 2, chopper.position.z));
	
  
		
			transform.position = Vector3.Lerp (transform.position, new Vector3 (chopper.position.x, chopper.position.y + offSetY, chopper.position.z - offSetZ), speed * Time.deltaTime);
			Vector3 playerlookAt = new Vector3(chopper.position.x,chopper.position.y + 2,chopper.position.z);
			SmoothLook (playerlookAt - transform.position);
	}
	void SmoothLook(Vector3 newDirection){
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection), (speed/2) * Time.deltaTime);
    }
}
