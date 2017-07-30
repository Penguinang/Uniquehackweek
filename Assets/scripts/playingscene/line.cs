using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("destroy", 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void destroy()
	{
		Destroy (gameObject);
	}
}
