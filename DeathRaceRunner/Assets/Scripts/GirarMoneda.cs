using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarMoneda : MonoBehaviour {

	int girarx  = 0;
	int girary = 0;
	int girarz = 4;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
			transform.Rotate(girarx, girary, girarz);
		}
		
	}

