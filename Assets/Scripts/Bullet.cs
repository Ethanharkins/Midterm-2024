using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    private Vector3 movementDirection;

    void Start()
    {
        // Assume the bullet's forward direction is the direction to move towards
        movementDirection = transform.forward;
    }

    void Update()
    {
        if (Time.timeScale > 0) // Move only when time is not frozen
        {
            transform.position += movementDirection * speed * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Handle collision (e.g., damage enemy, destroy bullet)
        Destroy(gameObject);
    }
}
