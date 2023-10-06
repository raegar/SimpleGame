using UnityEngine;

public class Coin : MonoBehaviour
{
    // OnTriggerEnter is called when another GameObject enters the trigger collider attached to this GameObject
    void OnTriggerEnter(Collider other)
    {
        // Check if the GameObject has a CoinCollecter component
        CoinCollecter character = other.GetComponent<CoinCollecter>();
        
        if (character != null)
        {
            // Call the CollectCoin method on the CoinCollecter component
            character.CollectCoin();
            
            // Destroy the coin
            Destroy(gameObject);
        }
    }
}
