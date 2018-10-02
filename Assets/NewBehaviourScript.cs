using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public Manager manager;

	// Use this for initialization
	void Start () {

        manager = GameObject.Find("Manager").GetComponent<Manager>();
		
	}
	
	// Update is called once per frame
	void Update () {

        
		
	}
}
