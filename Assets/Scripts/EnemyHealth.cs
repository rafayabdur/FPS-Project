using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    //public float startHealth = 100f;
    //public float health;


    // public Image healthBar;

    private void Start()
    {
        /*startHealth = 100f*/;
    }
    public void TakeDamageFromPlayer(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }

        // startHealth -= damage;

        //if (startHealth <= 0)
        //{
        //    Destroy(gameObject);
        //    Debug.Log("Die");
        //    gameObject.SetActive(false);
        //}
    }
}
