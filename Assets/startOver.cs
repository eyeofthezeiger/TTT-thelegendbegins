using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startOver : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void resetGame ()
    {
        var cubes = GameObject.FindObjectsOfType<CubeScript>();
        foreach(CubeScript cube in cubes){
            GameObject.Destroy(cube.gameObject);
        }
        Invoke("reInstantiate", 0.2f);
    }

    public void reInstantiate()
    {
        GameObject.Find("Manager").GetComponent<Manager>().createCubes();
    }
}
