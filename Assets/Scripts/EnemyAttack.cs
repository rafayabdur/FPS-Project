using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Health health;
    [SerializeField] float damage = 40f;

    void Start()
    {
        health = FindObjectOfType<Health>();
    }


    public void AttackHitEvent()
    {
        if (health == null) return;
      
        health.DamageHealth(damage);
        Debug.Log("bang bang");
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
        health.DamageHealth(damage);
        Debug.Log("Damaging");

        }
    }
}
