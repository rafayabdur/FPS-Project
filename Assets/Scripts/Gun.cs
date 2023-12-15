using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public float Damage = 10f;
    public float Range = 100f;
    public float fireRate = 15f;
    public float ImpactForce = 30f;
    private float nextTimeToFire = 0f;


    public int maxAmmo = 10;
    public int CurrentAmmo= -1;
    public float reloadTime = 2f;
    private bool isReloading = false;
    public Camera fpsCam;
    public ParticleSystem MuzzleFlash;
    public GameObject impactEffect;

    public Animator animator;

    public EnemyHealth enemyHealth;



    void Start()
    {
            CurrentAmmo = maxAmmo;
        
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            return;
        }
        
        if (CurrentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }


        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time * 1f / fireRate;
            Shoot();
            
            //Destroy(gameObject);
        }

    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime - 0.25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(0.25f);
        CurrentAmmo = maxAmmo;
        isReloading = false;

    }
    public void Shoot()
    {
        CurrentAmmo--;
        
        MuzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, Range))
        {
            Debug.Log(hit.transform.name);

           Target target =  hit.transform.GetComponent<Target>();
            enemyHealth = hit.transform.GetComponent<EnemyHealth>(); 
            if (target != null)
            {
                target.TakeDamage(Damage);
                

                    
            }

            if (enemyHealth!= null)
            {
                enemyHealth.TakeDamageFromPlayer(Damage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * ImpactForce);
            }

           GameObject ImpactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(ImpactGO, 0.2f); 
        }
        
    } 
}
