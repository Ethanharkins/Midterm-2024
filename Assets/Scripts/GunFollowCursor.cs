using UnityEngine;

public class GunFollowCursor : MonoBehaviour
{
    public Camera cam;
    public float defaultLookHeight = 1f; // Default height to look at in case of a straight horizontal aim

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            // If we don't hit anything, use a point far away from the camera
            targetPoint = ray.origin + ray.direction * 1000f;
        }

        // Keep the y position constant
        targetPoint.y = transform.position.y;

        Vector3 direction = targetPoint - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Euler(0, lookRotation.eulerAngles.y, 0);
    }
}
