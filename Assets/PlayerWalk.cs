using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float lookSpeed = 2.0f;

    private float rotationX = 0;

    void Update()
    {
        // Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = transform.TransformDirection(movement);
        transform.position += movement * moveSpeed * Time.deltaTime;

        // Rotation
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90, 90);

        transform.rotation *= Quaternion.Euler(0, mouseX, 0);

        // Rotate the camera
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        // Adjust camera position to cover the entire capsule
        Vector3 cameraOffset = new Vector3(0, 0.8f, 0); // Adjust this value based on your capsule's size and position
        Camera.main.transform.position = transform.position + cameraOffset;
    }
}
