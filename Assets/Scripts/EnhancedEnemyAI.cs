using UnityEngine;

public class EnhancedEnemyAI : MonoBehaviour
{
    public Vector3 movementDirection;
    public float changeDirectionEverySeconds = 5f;
    public float maxMovementSpeed = 5f;

    private Transform target;
    private float timer;

    void Start()
    {
        ChangeDirection();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > changeDirectionEverySeconds)
        {
            ChangeDirection();
            timer = 0;
        }

        MoveInDirection();
    }

    void ChangeDirection()
    {
        // Random new direction towards the target with some randomness
        if (target != null)
        {
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            Vector3 randomDirection = Random.insideUnitSphere;
            movementDirection = Vector3.Lerp(directionToTarget, randomDirection, 0.5f).normalized;
        }
        else
        {
            movementDirection = Random.insideUnitSphere.normalized;
        }
        movementDirection.y = 0; // Ensure movement is only horizontal
    }

    void MoveInDirection()
    {
        transform.position += movementDirection * maxMovementSpeed * Time.deltaTime;
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
