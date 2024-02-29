using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] cameraPositions;
    private int currentCameraIndex = 0;

    public void MoveToNextCameraPosition()
    {
        currentCameraIndex = (currentCameraIndex + 1) % cameraPositions.Length;
        transform.position = cameraPositions[currentCameraIndex].position;
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, -90, transform.eulerAngles.z);
    }

    // Call this method from a UI button to move the camera to the next position
    public void OnNextCameraButtonPressed()
    {
        MoveToNextCameraPosition();
    }
}
