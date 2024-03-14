using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    // Empty Reference acts as Empty Component Variable for Generic Code Object
    private CharacterController charController;
    public float speed = 6.0f;
    public float gravity = -9.8f;

    // Start is called before the first frame update
    void Start()
    {
        // Grabs the CharacterController component within the same game object.
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        // Limits diagonal movement to same speed as axis movement
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        movement *= Time.deltaTime;
        // Transform movement vector from local to global
        movement = transform.TransformDirection(movement);
        // Tell CharacterController to move by that vector
        charController.Move(movement);
    }
}
