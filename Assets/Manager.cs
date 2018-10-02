using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    private List<Transform> playerOneTransforms = new List<Transform>();
    private List<Transform> playerTwoTransforms = new List<Transform>();

    private enum PlayerTurn
    {
        One,
        Two
    }

    private PlayerTurn currentPlayer;

    private Vector3 mouseDownPosition;
    private bool mouseDown = false;

    // Use this for initialization
    void Start () {
        currentPlayer = PlayerTurn.One;
	}
	
	// Update is called once per frame
	void Update () {
        if (mouseDown)
        {
            //Camera.main.transform.parent.Rotate(Vector3.up, 1.5f);
            Camera.main.transform.parent.Rotate(Vector3.right, 1.5f);
        }
        if (Input.GetMouseButtonDown(0))
        {
            mouseDownPosition = Input.mousePosition;
            mouseDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (mouseDownPosition == Input.mousePosition)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 199.0f))
                {
                    if (hit.transform != null)
                    {
                        onCubeClicked(hit.transform);
                    }
                }
            }
            mouseDown = false;
        }
    }

    public void onCubeClicked (Transform transform)
    {
        Renderer renderer = transform.gameObject.GetComponent<Renderer>();
        if (renderer.material.color != Color.blue && renderer.material.color != Color.red)
        {
            if (currentPlayer == PlayerTurn.One)
            {
                playerOneTransforms.Add(transform);
                renderer.material.color = Color.blue;
                currentPlayer = PlayerTurn.Two;
            }
            else
            {
                playerTwoTransforms.Add(transform);
                renderer.material.color = Color.red;
                currentPlayer = PlayerTurn.One;
            }
        }
    }
}
