using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public GameObject cubePrefab;
    public ScoreManager scoreManager;

    private List<Transform> cubes = new List<Transform>();

    private enum PlayerTurn
    {
        One,
        Two
    }

    private PlayerTurn currentPlayer;

    private bool player1Winner = false;
    private bool player2Winner = false;



    // Use this for initialization
    void Start () {
        scoreManager = GetComponent<ScoreManager>();
        currentPlayer = PlayerTurn.One;
        DynamicGI.UpdateEnvironment();
        createCubes();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void onCubeClicked (Transform transform)
    {
        Renderer renderer = transform.gameObject.GetComponent<Renderer>();
        if (renderer.material.color != Color.blue && renderer.material.color != Color.red)
        {
            if (currentPlayer == PlayerTurn.One)
            {
                renderer.material.color = Color.blue;
                currentPlayer = PlayerTurn.Two;
                transform.gameObject.GetComponent<CubeScript>().player = 2;
            }
            else
            {
                renderer.material.color = Color.red;
                currentPlayer = PlayerTurn.One;
                transform.gameObject.GetComponent<CubeScript>().player = 1;
            }
            scoreManager.checkScore();
        }
    }

    

    public void createCubes()
    {
        cubes = new List<Transform>();
        Debug.Log("starting to create cubes");

        var size = 2;

        for(int x = -size; x <= size; x++)
        {
            for (int y = -size; y <= size; y++)
            {
                for (int z = -size; z <= size; z++)
                {
                    instantiateCube(x, y, z);
                }
            }
        }
    }

    private void instantiateCube(int x, int y, int z)
    {
        int offset = 0;
        if (x == 0 && y == 0 && z == 0)
        {
            Debug.Log("center, skipping");
        }
        else
        {
            GameObject cube = Instantiate(cubePrefab, new Vector3(x + offset, y, z), Quaternion.identity);
            cubes.Add(cube.transform);
            var script = cube.GetComponent<CubeScript>();
            script.gridLocation = new Vector3(x, y, z);
            
            if ((x == 0 && y == 0 && z != 0) ||
                (x != 0 && y == 0 && z == 0) ||
                (x == 0 && y != 0 && z == 0))
            {            
                cube.GetComponent<Renderer>().material.color = Color.gray;
            }
        }
    }
}
