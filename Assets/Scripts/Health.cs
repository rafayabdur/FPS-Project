using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Health : MonoBehaviour
{
    public float startHealth = 100f;
    public float health;
    public Image healthBar;
    public TextMeshProUGUI dieText;

    private void Start()
    {
        dieText.gameObject.SetActive(false);
        health = startHealth;
        healthBar.fillAmount = health / startHealth;




    }

    public void DamageHealth(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            //die
            Die();
            
        }
    }

    void Die()
    {
        dieText.gameObject.SetActive(true);
    }
}

