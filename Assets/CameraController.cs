using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject manager;

    private Vector3 mouseDownPosition;
    private bool mouseDown = false;
    private bool mouseMoved = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (mouseDown)
        {
            float difX = (Input.mousePosition.x - mouseDownPosition.x);
            float difY = (Input.mousePosition.y - mouseDownPosition.y);
            float scaledDiffX = difX * 0.25f;
            float scaledDiffY = difY * 0.35f;
            Transform camera = Camera.main.transform.parent;

            camera.Rotate(Vector3.right, -scaledDiffY, Space.World);
            camera.Rotate(Vector3.up, scaledDiffX, Space.World);
            camera.eulerAngles = new Vector3(camera.eulerAngles.x, camera.eulerAngles.y, 0);

            float clickTolerance = 1f;
            if (Mathf.Abs(difX) > clickTolerance || Mathf.Abs(difY) > clickTolerance)
            {
                mouseMoved = true;
            }

            mouseDownPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonDown(0))
        {
            mouseDownPosition = Input.mousePosition;
            mouseDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (mouseMoved == false)
            {

                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 199.0f))
                {
                    if (hit.transform != null)
                    {
                        manager.GetComponent<Manager>().onCubeClicked(hit.transform);
                    }
                }
            }
            mouseDown = false;
            mouseMoved = false;
        }
    }
}
