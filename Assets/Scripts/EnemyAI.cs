using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target; // The target for the enemy to move towards
    public float speed = 5.0f; // Speed at which the enemy moves
    public bool canMove = false; // Controlled by the GameManager

    private Vector3 movementDirection;

    private void Start()
    {
        if (target != null)
        {
            // Calculate initial movement direction with a slight random variation towards the target
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            Vector3 randomDirection = new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f));
            movementDirection = (directionToTarget + randomDirection).normalized;
        }
    }

    private void Update()
    {
        if (canMove)
        {
            MoveTowardsTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        // Move the enemy in the calculated direction
        transform.position += movementDirection * speed * Time.deltaTime;
    }

    // This method could be called by the GameManager to enable movement
    public void EnableMovement(bool enable)
    {
        canMove = enable;
    }
}
