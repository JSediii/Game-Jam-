using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Declare the event
    public static event System.Action OnEnemyDeath;

    // Call this method when the enemy dies
    public void Die()
    {
        // Invoke the event
        OnEnemyDeath?.Invoke();
        
        // Destroy the enemy
        Destroy(gameObject);
    }
}
