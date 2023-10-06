using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100; // Maximum health
    private int currentHealth; // Current health

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health
    }

    // Public method to deal damage to the entity
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        // Optionally, trigger any health-related UI updates or events here
        Debug.Log("Current Health: " + currentHealth);
    }

    // Public method to heal the entity
    public void Heal(int healingAmount)
    {
        currentHealth += healingAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        // Optionally, trigger any health-related UI updates or events here
        Debug.Log("Current Health: " + currentHealth);
    }

    // Public method to get the current health (read-only)
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
