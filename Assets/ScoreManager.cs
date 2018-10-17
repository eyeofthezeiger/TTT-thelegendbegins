using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void checkScore()
    {
        if (checkForThreeInARow(1))
        {
            Debug.Log("player 1 wins");
        }
        else if (checkForThreeInARow(2))
        {
            Debug.Log("player 2 wins");
        }
    }

    private bool checkForThreeInARow(int player)
    {
        //start at x = 1, y = 0, z = 0
        //check if is taken
        //check all adjacent squares that aren't checked

        return false;
    }
}
