using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField]
    private int startingHealth = 5;

    private int currentHealth;

    public Animator anim;

    [SerializeField]
    private AudioClip death;

    void Start()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }


    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        anim.SetBool("hit", true);

        if (anim.GetBool("hit") == true)
        {
            Invoke("hitfalse", 1);

        }

        if (currentHealth <= 0)
            Die();
    }

    private void Die()
    {
       
        anim.SetBool("die", true);
        gameObject.GetComponent<AudioSource>().clip = death;
        gameObject.GetComponent<AudioSource>().Play();
        Invoke("Death", 5);
        
    }

    private void hitfalse()
    {
        anim.SetBool("hit", false);
    }

    private void Death()
    {
        gameObject.SetActive(false);
    }

    }
