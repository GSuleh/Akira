using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;
using TMPro;

public class Playerhealth : MonoBehaviour
{
    [SerializeField]
    private float startingHealth = 20;

    private float currentHealth;

    private float timer = 60f;

    public TMP_Text textseconds;

    private float MaxHealth = 20;

    [SerializeField]
    private Slider HealthBar;

    public Animator anim;

    [SerializeField]
    private AudioClip death;

    [SerializeField]
    private AudioClip yes;


    void Start()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        HealthBar.value = currentHealth / MaxHealth;

        timer -= Time.deltaTime;
        textseconds.text = timer.ToString("f2");

        if(timer <= 0)
        {
            
            textseconds.text = "victory";
            win();
        }
        
    }


        public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        anim.SetBool("hit", true);

        if (anim.GetBool("hit") == true)
        {
            Invoke("hitfalse", 2);
            
        }

        if (currentHealth <= 0)
            Die();
    }

    
    private void Die()
    {
       
        anim.SetBool("dead", true);
        Cursor.lockState = CursorLockMode.None;
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
        SceneManager.LoadScene("start");
    }

    private void win()
    {
        gameObject.GetComponent<AudioSource>().clip = yes;
        gameObject.GetComponent<AudioSource>().Play();
        Invoke("victory", 10);
    }

    private void victory()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("start");
    }
}
    
