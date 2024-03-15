using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float verticalSpeed = 2.0f;
    public float rotationSpeed = 50.0f;

    // Update is called once per frame
    void Update()
    {
        // Vertical movement
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * verticalSpeed * Time.deltaTime, Space.World);
        }

        // Rotational movement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(transform.position, Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}

