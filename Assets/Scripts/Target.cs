using UnityEngine;

public class Target : MonoBehaviour
{
    public float Health = 50f;
    public GameObject DestroyedVersion;

    public void TakeDamage(float amount)
    {
        Health -= amount;
        if (Health <=0f)
        {
            Die();
        }
    }
    void Die()
    {

        Instantiate(DestroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    
}
