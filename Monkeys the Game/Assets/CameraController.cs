using UnityEngine;

public class CameraController : MonoBehaviour {

    public float panSpeed = 20f;
    public Vector2 panLimitX; //how far camera can pan horizontally before it clamps
    public Vector2 panLimitY; //how far camera can pan vertically before it clamps

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
        }
        if (Input.GetKey("s"))
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("q"))
        {
            pos.y -= zoomSpeed * 1f * Time.deltaTime;
        }
        if (Input.GetKey("e"))
        {
            pos.y += zoomSpeed * 1f * Time.deltaTime;
        }

        //this controls the zoom
        float zoom = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= zoom * zoomSpeed * 20f * Time.deltaTime;

        //this controls panning and zooming limits
        pos.x = Mathf.Clamp(pos.x, panLimitX.x, panLimitX.y);
        pos.y = Mathf.Clamp(pos.y, zoomLimitMin, zoomLimitMax);
        pos.z = Mathf.Clamp(pos.z, panLimitY.x, panLimitY.y);//use y because we used vector2, so this y is actually our z

        transform.position = pos;
    }
}
