using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    // Private variable that has reference to Camera
    private Camera cam;
    private int score;

    // bullet hit effect prefab
    public GameObject BulletHitPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Get reference to camera
        // Camera is currently attached to player
        cam = GetComponent<Camera>();
        score = 0;

        // Hide cursor at center of screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // OnGUI unity method to draw crosshairs onscreen
    void OnGUI()
    {
        // font size
        int size = 12;

        // Coords at which the crosshairs are drawn
        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 2;

        // Draw the crosshairs as text (e.g. asterisk)
        GUI.Label(new Rect(posX, posY, size, size), "*");

        GUI.Label(new Rect(10, 20, 100, 20), $"Score: {score}");

    }

    // Update is called once per frame
    void Update()
    {
        // 0 for left button, 1 for right button, 2 for the middle button
        if (Input.GetMouseButtonDown(0))
        {
            // Use a Vector3 to store the location of the middle of the screen
            // Divide the width and height by 2 to get the midpoint; these become
            // pixelWidth and pixelHeight give you size of the screen
            // the x and y values of the vector, with the z value being zero
            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);

            // Create a ray by calling ScreenPointToRay
            // Pass in the point, as this is used as the origin for the ray
            Ray ray = cam.ScreenPointToRay(point);

            // Create a RaycastHit object to figure out where the ray hit
            RaycastHit hit;

            // out parameter uses same reference
            if (Physics.Raycast(ray, out hit))
            {
                // Get reference to object that was hit
                // Uses transform component's gameObject property
                GameObject hitObject = hit.transform.gameObject;

                // Get reference to object's ReactiveTarget Script if it exists
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();

                // If ray hits enemy, indicate an enemy was hit, otherwise place a sphere
                if (target != null)
                {
                    score++;
                    target.ReactToHit();
                }
                else
                {
                    // Bullet hit effect at hit point
                    CreateBulletHitEffect(hit.point + hit.normal * 0.001f, hit.normal);
                }

            }
        }
    }

    private void CreateBulletHitEffect(Vector3 pos, Vector3 hitNormal)
    {
        // Instantiate the bullet hit effect at the hit point
        GameObject bulletHitEffect = Instantiate(BulletHitPrefab, pos, Quaternion.LookRotation(hitNormal));

        Destroy(bulletHitEffect, 1f);
    }

    public int getScore()
    {
        return score;
    }

    public void resetScore()
    {
        score = 0;
    }

}