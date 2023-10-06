using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int damageAmount = 20; // Amount of damage this weapon deals

    // OnCollisionEnter is called when this collider/rigidbody starts touching another rigidbody/collider
    void OnCollisionEnter(Collision collision)
    {
        // Check if the object we collided with has a Health component
        Health enemyHealth = collision.gameObject.GetComponent<Health>();
        
        if (enemyHealth != null)
        {
            // Call the TakeDamage method on the Health component
            enemyHealth.TakeDamage(damageAmount);

            // Optionally, you can add more logic here, like destroying the weapon after use
        }
    }
}
