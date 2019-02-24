using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearOnPlay : MonoBehaviour {

    public Renderer rend;
	void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
		
	}
	
}
