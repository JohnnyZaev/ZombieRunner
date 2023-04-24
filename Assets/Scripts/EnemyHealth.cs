using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;

    public void TakeDamage(int damage)
    {
        health -= Mathf.Abs(damage);
        if (health < 1)
            Destroy(gameObject);
    }
    
}
