using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;


using Debug = UnityEngine.Debug;

public class gun : MonoBehaviour
{
    [SerializeField]
    [Range(0.5f, 1.5f)]
    private float firerate = 0.5f;

    [SerializeField]
    [Range(1, 10)]
    private int damage = 1;

    

    [SerializeField]
    private Transform firepoint;

    [SerializeField]
    private AudioSource gunshot;

    private float timer;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {

        gunshot = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        anim.SetBool("isaim", false);
        if (timer >= firerate)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0f;
                FireGun();
                gunshot.Play();
            }
        }
    }


    private void FireGun()
    {
        Debug.DrawRay(firepoint.position, firepoint.forward * 100, Color.red, 2f);
        Ray ray = new Ray(firepoint.position, firepoint.forward);
        
        RaycastHit hitInfo;

        anim.SetBool("isaim", true);
   

        if(Physics.Raycast(ray, out hitInfo, 100))
        {
            var objhealth = hitInfo.collider.GetComponent<Health>();

            if (objhealth != null)
                objhealth.TakeDamage(damage);
        }
    }
}
