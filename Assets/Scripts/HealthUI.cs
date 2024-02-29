using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image healthBar;
    public Health healthComponent; // Assume you have a Health script attached to your towers and enemies

    void Update()
    {
        healthBar.fillAmount = healthComponent.currentHealth / healthComponent.maxHealth;
    }
}
