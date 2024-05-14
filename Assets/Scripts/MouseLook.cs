using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public enum RotationAxes {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    public float verticalRot = 0;

    // Update is called once per frame
    void Update()
    {
        if(!PauseMenu.GameIsPaused)
        {
            if (axes == RotationAxes.MouseX) {
                // horizontal rotation here
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
            }
            else if (axes == RotationAxes.MouseY) {
                // vertical rotation here
                verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert;
                verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

                float horizontalRot = transform.localEulerAngles.y;

                transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
            }
            else {
                // both x and y rotations here
                verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert;
                verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

                float delta = Input.GetAxis("Mouse X") * sensitivityHor;
                float horizontalRot = transform.localEulerAngles.y + delta;

                transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
            }
        }
    }
}
