using UnityEngine;

public class CameraController : MonoBehaviour {

    public Camera cam;

    public float panSpeed = 20f;
    public Vector2 panLimitX; //how far camera can pan horizontally before it clamps
    public Vector2 panLimitY; //how far camera can pan vertically before it clamps
    public GameObject focus; //object to focus camera on if it's selected

    public float zoomSpeed = 20f;
    public float zoomLimitMin = 20f; //height in Y for how far in we can zoom before clamp
    public float zoomLimitMax = 120f; //height in Y for how far out we can zoom
   
    //public Camera cam; //possibly will be used for more dynamic pan limits

    // Update is called once per frame
    void Update () {

        Vector3 pos = transform.position;
        //this controls camera panning with wasd
        if (Input.GetKey("w")){
            pos.z += panSpeed * Time.deltaTime;
            RemoveFocus();
        }
        if (Input.GetKey("s"))
        {
            pos.z -= panSpeed * Time.deltaTime;
            RemoveFocus();
        }
        if (Input.GetKey("d"))
        {
            pos.x += panSpeed * Time.deltaTime;
            RemoveFocus();
        }
        if (Input.GetKey("a"))
        {
            pos.x -= panSpeed * Time.deltaTime;
            RemoveFocus();
        }
        if (Input.GetKey("q"))
        {
            pos.y -= zoomSpeed * 1f * Time.deltaTime;
            RemoveFocus();
        }
        if (Input.GetKey("e"))
        {
            pos.y += zoomSpeed * 1f * Time.deltaTime;
            RemoveFocus();
        }
        //set target for camera to focus on (only friendly monkeys)
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);//should use viewport, but is demo
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Monkey")
                {
                    GameObject target = hit.collider.gameObject;
                    SetFocus(target);
                }


            }


        }
    


        //this controls the zoom
        float zoom = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= zoom * zoomSpeed * 20f * Time.deltaTime;

        //this controls panning and zooming limits
        pos.x = Mathf.Clamp(pos.x, panLimitX.x, panLimitX.y);
        pos.y = Mathf.Clamp(pos.y, zoomLimitMin, zoomLimitMax);
        pos.z = Mathf.Clamp(pos.z, panLimitY.x, panLimitY.y);//use y because we used vector2, so this y is actually our z
        
        //this allows camera to focus on target
        if (focus != null)
        {
            pos.x = focus.transform.position.x;
            pos.z = focus.transform.position.z - 0.6f * Mathf.Abs(pos.y); //scale offset by zoom level
            //transform.LookAt(focus.transform); keeping here because cool function, but not what we need
        }
        transform.position = pos;
    }


    void SetFocus(GameObject newFocus)
    {
        focus = newFocus;
    }

    void RemoveFocus()
    {
        focus = null;
    }

}
