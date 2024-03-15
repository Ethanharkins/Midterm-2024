using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float startHealth = 100;
    private float health;

    public int worth = 50;

    public GameObject deathEffect;

    [Header("Unity Stuff")]
   

    private bool isDead = false;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        isDead = true;

        PlayerStats.Money += worth;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }

    // This function gets called when the collider attached to this GameObject collides with another GameObject.
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the tag 'End'
        if (other.gameObject.CompareTag("End"))
        {
            PlayerStats.Lives--; // Deduct a life from the player's lives.
            Destroy(gameObject); // Destroy this enemy GameObject.
        }
    }
}
