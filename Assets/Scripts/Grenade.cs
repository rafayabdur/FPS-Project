using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 5f;
    public float Countdown;
    public float force = 700f;
    bool HasExploded = false;
    public GameObject explosionEffect;

    void Start()
    {
        Countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        Countdown -= Time.deltaTime;
        if (Countdown <= 0f && !HasExploded)
        {
            Explode();
            HasExploded = true;
        }
    }
        void Explode()
    {
        Debug.Log("BOOM!!");
        Instantiate(explosionEffect , transform.position , transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position , radius);
        foreach  (Collider nearbyObject in colliders)
        {
           Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb !=null)
            {
                rb.AddExplosionForce(force , transform.position , radius);
            }
        }
        Destroy(gameObject);
    }
        
}
